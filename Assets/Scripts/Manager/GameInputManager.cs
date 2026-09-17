using UnityEngine;
using UnityEngine.UI;

public enum InputID
{
    MainAction,
    Spacebar,
    MouseX,
    MouseY,
    MouseScrollWheel
}

public class GameInputManager : MonoBehaviour
{
    public static bool m_zoomTouchLastFrame = false;
    public static bool m_zoomTouchThisFrame = false;
    public static int m_fingerCount = 0;
    public static Touch m_touch0;
    public static Touch m_touch1;
    public static float m_currentZoomFingerSeparation;
    public static float m_prevZoomFingerSeparation;
    public static Vector2 m_zoomTouchCenter;
    public static float m_touchZoomChange = 0f;
    public static Vector3 m_zoomFingerCenterWorldPreZoom = Vector3.zero;
    public static Vector3 m_zoomFingerCenterWorldPostZoom = Vector3.zero;
    public static Vector3 m_panDisplacementFromZooming = Vector3.zero;
    public static Vector3 m_lastMouseFingerPositionWorldSpace;
    public static bool m_objectUnderCursorSet = false;
    public static ObjectForDraw m_objectUnderCursor = null;
    public static float noInputTime = 0f;
    public static bool noInput = true;
    public static Vector3 lastMousePosition;

    public static bool IsPlayerIdle()
    {
        //lastMousePosition = Input.mousePosition;

        // 检查是否有水平/垂直输入（键盘/控制器）
        bool noMovement = Mathf.Approximately(0f, Input.GetAxis("Horizontal")) && Mathf.Approximately(0f, Input.GetAxis("Vertical"));

        // 检查是否有鼠标输入（没有点击或者鼠标移动）
        bool noMouseMovement = (Input.mousePosition - lastMousePosition).sqrMagnitude < 0.01f && Input.GetAxis(InputID.MouseScrollWheel.ToString()) == 0f && !GameInputManager.JustPressedInputPrincess(KeyInputID.MainAction);
        lastMousePosition = Input.mousePosition;

        // 检查触摸输入（对于触摸屏设备）
        bool noTouchInput = Input.touchCount == 0;

        // 玩家没有任何输入时返回true
        return noMovement && noTouchInput && noMouseMovement;
    }

    public static Vector2 Touch0Position
    {
        get
        {
            return GameInputManager.m_touch0.position;
        }
    }

    public static int MouseFingerX
    {
        get
        {
            if (GameInputManager.m_fingerCount > 0)
            {
                Vector2 touch0Position = GameInputManager.Touch0Position;
                return (int)touch0Position.x;
            }
            Vector3 mousePosition = Input.mousePosition;
            return (int)mousePosition.x;
        }
    }

    public static int MouseFingerY
    {
        get
        {
            if (GameInputManager.m_fingerCount > 0)
            {
                Vector2 touch0Position = GameInputManager.Touch0Position;
                return (int)touch0Position.y;
            }
            Vector3 mousePosition = Input.mousePosition;
            return (int)mousePosition.y;
        }
    }

    public static Vector2 MouseFingerPosition
    {
        get
        {
            return new Vector2(GameInputManager.MouseFingerX, GameInputManager.MouseFingerY);
        }
    }

    public static Vector3 MouseFingerPositionWorldSpace
    {
        get
        {
            return CameraControl.Instance.cameraController.ScreenToWorldPoint(new Vector3(GameInputManager.MouseFingerX, GameInputManager.MouseFingerY, 0f - CameraControl.Instance.Z));
        }
    }

    public static Vector3 MouseFingerFrameDisplacementWorldSpace
    {
        get
        {
            if (GameInputManager.ZoomTouch_IsZooming)
            {
                return GameInputManager.m_panDisplacementFromZooming + GameInputManager.MouseFingerPositionWorldSpace - GameInputManager.m_lastMouseFingerPositionWorldSpace;
            }
            return GameInputManager.MouseFingerPositionWorldSpace - GameInputManager.m_lastMouseFingerPositionWorldSpace;
        }
    }

    public static float MouseFingerXPercent
    {
        get
        {
            return (float)GameInputManager.MouseFingerX / (float)Screen.width;
        }
    }

    public static float MouseFingerYPercent
    {
        get
        {
            return (float)GameInputManager.MouseFingerY / (float)Screen.height;
        }
    }

    public static float MouseFingerX_WorldSpace
    {
        get
        {
            Vector3 mouseFingerPositionWorldSpace = GameInputManager.MouseFingerPositionWorldSpace;
            return mouseFingerPositionWorldSpace.x;
        }
    }

    public static float MouseFingerY_WorldSpace
    {
        get
        {
            Vector3 mouseFingerPositionWorldSpace = GameInputManager.MouseFingerPositionWorldSpace;
            return mouseFingerPositionWorldSpace.y;
        }
    }

    public static GridCell CellUnderCursor
    {
        get
        {
            return GridCellsMgr.Instance.GetCell(GameInputManager.MouseFingerX_WorldSpace, GameInputManager.MouseFingerY_WorldSpace, false, false);
        }
    }

    public static ObjectForDraw ObjectUnderCursor
    {
        get
        {
            if (!GameInputManager.m_objectUnderCursorSet)
            {
                GameInputManager.m_objectUnderCursor = GameMgr.GetUnderlyingObjectScreenPointPrincess(GameInputManager.MouseFingerX, GameInputManager.MouseFingerY);
                GameInputManager.m_objectUnderCursorSet = true;
            }
            return GameInputManager.m_objectUnderCursor;
        }
    }


    public static void LateUpdate_PlayingState()
    {
        GameInputManager.RefreshTouchesPrincess();
        MasterObjectMover.Instance.CustomLateUpdatePrincess();
    }

    public static void LastUpdatePrincess()
    {
        GameInputManager.m_objectUnderCursorSet = false;
        GameInputManager.m_objectUnderCursor = null;

        GameInputManager.m_lastMouseFingerPositionWorldSpace = GameInputManager.MouseFingerPositionWorldSpace;
        GameInputManager.m_zoomTouchLastFrame = GameInputManager.m_zoomTouchThisFrame;
        if (GameInputManager.m_fingerCount > 1)
        {
            GameInputManager.m_prevZoomFingerSeparation = GameInputManager.m_currentZoomFingerSeparation;
        }
    }

    public static void RefreshTouchesPrincess()
    {
        GameInputManager.m_fingerCount = Input.touchCount;
        if (Input.touchCount > 0)
        {
            GameInputManager.m_touch0 = Input.GetTouch(0);
        }
        if (Input.touchCount > 1)
        {
            GameInputManager.m_touch1 = Input.GetTouch(1);
            GameInputManager.m_currentZoomFingerSeparation = Vector2.Distance(GameInputManager.m_touch0.position, GameInputManager.m_touch1.position);
        }
        GameInputManager.m_zoomTouchThisFrame = ((Input.touchCount == 2) ? true : false);
        if (GameInputManager.m_zoomTouchThisFrame)
        {
            GameInputManager.m_zoomTouchCenter = GameInputManager.m_touch0.position + (GameInputManager.m_touch1.position - GameInputManager.m_touch0.position) / 2f;
        }
        if (GameInputManager.ZoomTouch_IsZooming)
        {
            GameInputManager.m_touchZoomChange = GameInputManager.m_currentZoomFingerSeparation - GameInputManager.m_prevZoomFingerSeparation;
        }
    }

    public static bool ZoomTouch_IsZooming
    {
        get
        {
            return GameInputManager.m_zoomTouchLastFrame && GameInputManager.m_zoomTouchThisFrame;
        }
    }

    public static float ZoomUnits
    {
        get
        {
            if (GameInputManager.ZoomTouch_IsZooming)
            {
                float num = GameInputManager.m_touchZoomChange / ((float)(Screen.width + Screen.height) / 2f);
                return num * 2.5f;
            }
            return Input.GetAxis(InputID.MouseScrollWheel.ToString());
        }
    }

    public static void BeforeZoomPrincess()
    {
        if (GameInputManager.m_zoomTouchThisFrame)
        {
            GameInputManager.m_zoomFingerCenterWorldPreZoom = CameraControl.Instance.cameraController.ScreenToWorldPoint(GameMgr.Vec3(GameInputManager.m_zoomTouchCenter));
        }
    }

    public static void AfterZoomPrincess()
    {
        if (GameInputManager.m_zoomTouchThisFrame)
        {
            GameInputManager.m_zoomFingerCenterWorldPostZoom = CameraControl.Instance.cameraController.ScreenToWorldPoint(GameMgr.Vec3(GameInputManager.m_zoomTouchCenter));
            GameInputManager.m_panDisplacementFromZooming = GameInputManager.m_zoomFingerCenterWorldPostZoom - GameInputManager.m_zoomFingerCenterWorldPreZoom;
        }
    }

    public static void SkippedZoomPrincess()
    {
        GameInputManager.m_panDisplacementFromZooming = Vector3.zero;
    }

    public static bool JustPressedInputPrincess(KeyInputID key)
    {
        if (key == KeyInputID.MainAction && GameInputManager.m_fingerCount > 0)
        {
            return GameInputManager.m_touch0.phase == TouchPhase.Began;
        }
        return Input.GetButtonDown(key.ToString());
    }

    public static bool JustReleasedInputPrincess(KeyInputID key)
    {
        if (key == KeyInputID.MainAction && GameInputManager.m_fingerCount > 0)
        {
            return GameInputManager.m_touch0.phase == TouchPhase.Ended || GameInputManager.m_touch0.phase == TouchPhase.Canceled;
        }
        return Input.GetButtonUp(key.ToString());
    }

    public static float ConvertScreenToInchesPrincess(float screenPixelAmount)
    {
        return screenPixelAmount / Screen.dpi;
    }

    public static bool IsPressedDownPrincess(KeyInputID key)
    {
        if (key == KeyInputID.MainAction && GameInputManager.m_fingerCount > 0)
        {
            return GameInputManager.m_touch0.phase != TouchPhase.Ended && GameInputManager.m_touch0.phase != TouchPhase.Canceled;
        }
        return Input.GetButton(key.ToString());
    }
}
