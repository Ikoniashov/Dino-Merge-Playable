using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

public enum KeyInputID
{
    MainAction,
    Spacebar
}

public enum CameraStateID
{
    Idle,
    PreDragBuffer,
    Drag,
    DragResidual,
    GlideToFollowTarget,
    Follow,
    JumpToObject,
    JumpToPosition,
    GlideToPosition
}

public class CameraControl : MonoBehaviour
{
    public static CameraControl Instance { get; private set; }

    public CameraStateID State;
    [HideInInspector] public bool isRestricted;
    public Camera cameraController;
    public bool HorizontalLock;
    public Queue<Vector3> dragHistory = new Queue<Vector3>();
    [HideInInspector] public ObjectForDraw targetObject;
    [HideInInspector] public Vector3 offsetFromCenter = Vector3.zero;
    [HideInInspector] public Vector3 InitialScreenDragTapLocation;
    public Vector3 focusPosition;
    public float speedOfSwoop = 0.075f;
    public Action onCameraTransitionComplete;
    [HideInInspector] public Timer dragTimeRemaining = new Timer();
    public float remainingDragTime = 2f;
    [HideInInspector] public Vector3 remainingVelocity;
    [HideInInspector] public Vector3 velocityAtMouseUp;
    public float minimumZoom;
    public float maximumZoom;
    public float InitialZoom;
    public Bounds bounds;
    public WatcherForShake shakingHandler;
    public bool canDragAndZoom = false; 


    public float ZoomCounteractionScale
    {
        get
        {
            return this.cameraController.orthographicSize / this.InitialZoom;
        }
    }

    public float X
    {
        get
        {
            return CameraControl.Instance.transform.position.x;
        }
    }

    public float Y
    {
        get
        {
            return CameraControl.Instance.transform.position.y;
        }
    }

    public float Z
    {
        get
        {
            return CameraControl.Instance.transform.position.z;
        }
    }

    public float HorizontalLockYPos
    {
        get
        {
            if (!this.HorizontalLock)
            {
                Debug.LogError("Trying to get a Horizontal Lock Position for the camera when it's not supposed to be locked to the Horizontal.");
            }
            return this.Y;
        }
    }

    public Vector3 Position
    {
        get
        {
            return this.cameraController.transform.position;
        }
    }

    public static Camera Camera
    {
        get
        {
            return CameraControl.Instance.cameraController;
        }
    }

    public static WatcherForShake ShakeHandler
    {
        get
        {
            return CameraControl.Instance.shakingHandler;
        }
    }


    public bool IsCameraDraggingPrincess()
    {
        return this.State == CameraStateID.Drag;
    }

    public bool IsCameraInPreDragBufferPrincess()
    {
        return this.State == CameraStateID.PreDragBuffer;
    }

    public void AdjustCameraPositionPrincess(Vector3 moveBy)
    {
        float x = this.X + moveBy.x;
        float y = (!this.HorizontalLock) ? (this.Y + moveBy.y) : this.HorizontalLockYPos;
        float z = this.Z + moveBy.z;

        Vector3 position = new Vector3(x, y, z);
        if (this.State == CameraStateID.Drag)
        {
            if (this.HorizontalLock)
            {
                moveBy = new Vector3(moveBy.x, 0f, moveBy.z);
            }
            this.CaptureDragHistoryPrincess(moveBy);
        }
        this.cameraController.transform.position = position;
    }

    public void CaptureDragHistoryPrincess(Vector3 displacement)
    {
        this.dragHistory.Enqueue(displacement);
        if (this.dragHistory.Count > 4)
        {
            this.dragHistory.Dequeue();
        }
    }

    public float ConvertScreenToWorldLengthPrincess(float pixels)
    {
        Vector3 position = new Vector3(pixels, 0f, 0f);
        Vector3 vector = this.cameraController.ScreenToWorldPoint(position);
        Vector3 vector2 = this.cameraController.ScreenToWorldPoint(Vector3.zero);
        return vector.x - vector2.x;
    }

    public void ResetFollowTargetPrincess()
    {
        this.targetObject = null;
        if (this.State == CameraStateID.Follow || this.State == CameraStateID.GlideToFollowTarget)
        {
            this.State = CameraStateID.Idle;
        }
        this.offsetFromCenter = Vector3.zero;
    }

    

    public void UpdateGlidePositionPrincess()
    {
        Vector2 a = this.focusPosition - this.Position + this.offsetFromCenter;
        a *= this.speedOfSwoop * (Time.deltaTime * 60f);
        Vector2 a2 = new Vector2(this.X + a.x, this.Y + a.y);
        float num = Vector2.Distance(a2, this.focusPosition + this.offsetFromCenter);
        if (num <= 0.01f)
        {
            if (this.onCameraTransitionComplete != null)
            {
                this.onCameraTransitionComplete();
                this.onCameraTransitionComplete = null;
                this.speedOfSwoop = 0.075f;
            }
            a2 = this.focusPosition + this.offsetFromCenter;
            this.State = CameraStateID.Idle;
            this.offsetFromCenter = Vector3.zero;
        }
        CameraControl.Instance.cameraController.transform.position = new Vector3(a2.x, a2.y, this.Z);
    }

    public float DetermineOrthoSizePrincess()
    {
        float num = Math.Abs(GameInputManager.ZoomUnits * 10f);
        float value;
        if (GameInputManager.ZoomUnits < 0f)
        {
            value = CameraControl.Instance.cameraController.orthographicSize + CameraControl.Instance.cameraController.orthographicSize * 0.12f * num;
        }
        else
        {
            value = CameraControl.Instance.cameraController.orthographicSize - CameraControl.Instance.cameraController.orthographicSize * 0.12f * num;
        }
        return Mathf.Clamp(value, this.minimumZoom, this.maximumZoom);
    }

    public void DetectZoomPrincess()
    {
        if (GameInputManager.ZoomUnits != 0f)
        {
            GameInputManager.BeforeZoomPrincess();
            this.cameraController.orthographicSize = this.DetermineOrthoSizePrincess();
            GameInputManager.AfterZoomPrincess();
        }
        else
        {
            GameInputManager.SkippedZoomPrincess();
        }
        KeepRange.Instance.LateUpdate_KeepBgRange();
    }

    public bool DetectDragPrincess()
    {
        if (GameInputManager.JustPressedInputPrincess(KeyInputID.MainAction) && (GameInputManager.ObjectUnderCursor == null || !GameInputManager.ObjectUnderCursor.IsInADraggableState() || MasterObjectMover.CheckIfSelectedObjectAndClickOnDifferentObjectPrincess() || !MasterObjectMover.MainActionInsideSelectionAreaPrincess()))
        {
            this.State = CameraStateID.PreDragBuffer;
            this.targetObject = null;
            this.offsetFromCenter = Vector3.zero;
            this.InitialScreenDragTapLocation = GameInputManager.MouseFingerPosition;
            this.dragHistory.Clear();
            return true;
        }
        return false;
    }

    public void LateUpdate_PreDragBuffer()
    {
        if (GameInputManager.JustReleasedInputPrincess(KeyInputID.MainAction))
        {
            this.State = CameraStateID.Idle;
            return;
        }
        if (this.isRestricted)
        {
            return;
        }
        float num = GameInputManager.ConvertScreenToInchesPrincess(Vector3.Distance(this.InitialScreenDragTapLocation, GameInputManager.MouseFingerPosition));
        if (num >= 0.15f)
        {
            if (canDragAndZoom) this.State = CameraStateID.Drag;
        }
    }

    public void LateUpdate_Idle()
    {
        if (!this.DetectDragPrincess())
        {
            //this.DetectEdgeScrollingPrincess();
        } 
    }

    public void LateUpdate_Drag()
    {
        this.AdjustCameraPositionPrincess(-GameInputManager.MouseFingerFrameDisplacementWorldSpace);
        if (GameInputManager.JustReleasedInputPrincess(KeyInputID.MainAction))
        {
            this.State = CameraStateID.DragResidual;
            this.dragTimeRemaining.Set(this.remainingDragTime);
            this.remainingVelocity = Vector3.zero;
            int num = this.dragHistory.Count - 1;
            int num2 = 0;
            foreach (Vector3 b in this.dragHistory)
            {
                if (num2 >= num)
                {
                    break;
                }
                this.remainingVelocity += b;
                num2++;
            }
            if (num2 > 0)
            {
                this.remainingVelocity /= (float)num2;
            }
            this.velocityAtMouseUp = this.remainingVelocity;
        }
    }

    public void LateUpdate_DragResidual()
    {
        if (this.DetectDragPrincess())
        {
            return;
        }
        if (this.dragTimeRemaining.Done)
        {
            this.State = CameraStateID.Idle;
            return;
        }
        this.remainingVelocity = this.dragTimeRemaining.PercentLeft * this.dragTimeRemaining.PercentLeft * this.dragTimeRemaining.PercentLeft * this.velocityAtMouseUp;
        this.AdjustCameraPositionPrincess(this.remainingVelocity);
        this.dragTimeRemaining.Update(Time.deltaTime);
        if (this.remainingVelocity.magnitude <= 0.0025f)
        {
            this.State = CameraStateID.Idle;
        }
    }

    public void LateUpdate_Custom()
    {
        if (canDragAndZoom) this.DetectZoomPrincess();
        if (this.State == CameraStateID.Idle)
        {
            this.LateUpdate_Idle();
        }
        else if (this.State == CameraStateID.PreDragBuffer)
        {
            this.LateUpdate_PreDragBuffer();
        }
        else if (this.State == CameraStateID.Drag)
        {
            this.LateUpdate_Drag();
        }
        else if (this.State == CameraStateID.DragResidual)
        {
            this.LateUpdate_DragResidual();
        }
    }
    
    private IEnumerator MoveCoroutine(Vector3 targetPosition, float moveTime, System.Action onComplete = null)
    {
        Vector3 startPosition = transform.position;  // 当前的起始位置
        float elapsedTime = 0f;
        // 在指定的时间内平滑过渡
        while (elapsedTime < moveTime)
        {
            // 计算过渡过程中的比例
            float t = elapsedTime / moveTime;
            // 使用 Lerp 来平滑过渡
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;  // 增加已用时间
            yield return null;  // 等待下一帧
        }
        // 确保物体最终位置是目标位置
        transform.position = targetPosition;
        // 执行回调（如果有的话）
        onComplete?.Invoke();
    }

    public void MoveTo(Vector3 targetPosition, float moveTime, System.Action onComplete = null)
    {
        StartCoroutine(MoveCoroutine(targetPosition, moveTime, onComplete));
    }

    private IEnumerator ZoomCoroutine(float targetSize, float zoomTime, System.Action onComplete = null)
    {
        float startSize = this.cameraController.orthographicSize;  // 当前摄像机的正交大小
        float elapsedTime = 0f;
        // 在指定的时间内平滑过渡到目标缩放
        while (elapsedTime < zoomTime)
        {
            // 计算过渡比例
            float t = elapsedTime / zoomTime;
            // 使用 Lerp 来平滑过渡
            this.cameraController.orthographicSize = Mathf.Lerp(startSize, targetSize, t);
            elapsedTime += Time.deltaTime;  // 增加已用时间
            yield return null;  // 等待下一帧
        }
        // 确保摄像机最终大小为目标值
        this.cameraController.orthographicSize = targetSize;
        // 执行回调（如果有的话）
        onComplete?.Invoke();
    }

    public void ZoomTo(float targetSize, float zoomTime, System.Action onComplete = null)
    {
        StartCoroutine(ZoomCoroutine(targetSize, zoomTime, onComplete));
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;

        this.InitialZoom = this.cameraController.orthographicSize;

        this.transform.localPosition = new Vector3(this.bounds.center.x, this.bounds.center.y,this.transform.localPosition.z);
        this.cameraController.orthographicSize = 2.4f;
    }
}
