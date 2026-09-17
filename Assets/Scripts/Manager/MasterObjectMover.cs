using System;
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;

public enum ObjectMovementStateID
{
    None,
    ObjectSelected_MouseDown,
    ObjectSelected_NoMouseDown,
    ObjectSelected_ReclickMouseDownOnSameObject,
    ObjectSelected_ReclickMouseDownOnNothingSelectable,
    ObjectSelected_ReclickMouseDownOnNewSelectableObject,
    MonsterSelected_ReclickMouseDownOnNonMonster,
    ObjectSwapTriggered_MouseStillDown,
    ObjectDragging
}

public class MasterObjectMover
{
    public static MasterObjectMover _instance;

    public ObjectForDraw activeObject;
    public ObjectMovementStateID State = ObjectMovementStateID.None;
    public ObjectForDraw previousObject;
    public Vector2 originalClickPoint;
    public Vector2 originalClickPointOffsetFromRoot;
    public Timer tapTimer = new Timer(0.6f);
    public bool ignoringInputUntilMouseUp;
    public bool playerRecentlyDraggedOrScaled;
    public int numTaps;
    public static bool MouseDownOnNewObjectAlwaysSelectsNewObject = true;
    public static bool AllowTapTapToSwapObjects;
    public bool useOffsetMousePosition = true;


    public static MasterObjectMover Instance
    {
        get
        {
            if (MasterObjectMover._instance == null)
            {
                MasterObjectMover._instance = new MasterObjectMover();
            }
            return MasterObjectMover._instance;
        }
    }

    public int OffsetMouseX
    {
        get
        {
            return GameInputManager.MouseFingerX + (int)this.originalClickPointOffsetFromRoot.x;
        }
    }

    public int OffsetMouseY
    {
        get
        {
            return GameInputManager.MouseFingerY + (int)this.originalClickPointOffsetFromRoot.y;
        }
    }


    public void PerformActiveObjectDeselectionPrincess(bool calledFromDrawnObjectDeselect = false)
    {
        this.State = ObjectMovementStateID.None;
        if (this.activeObject == null)
        {
            return;
        }
        this.previousObject = this.activeObject;
        this.activeObject = null;
        if (!calledFromDrawnObjectDeselect)
        {
            this.previousObject.Deselect();
        }
    }

    public void IsDeselectIfActiveObjectPrincess(ObjectForDraw toDeselect, bool calledFromDrawnObjectDeselect)
    {
        if (toDeselect == null)
        {
            return;
        }
        if (toDeselect != this.activeObject)
        {
            return;
        }
        this.PerformActiveObjectDeselectionPrincess(calledFromDrawnObjectDeselect);
    }

    public void CaptureOriginalClickPointAndOffsetPrincess()
    {
        this.originalClickPoint = GameInputManager.MouseFingerPosition;
        if (this.activeObject == null)
        {
            return;
        }
        Vector3 vector = CameraControl.Instance.cameraController.WorldToScreenPoint(new Vector3(this.activeObject.Root.transform.position.x, this.activeObject.Root.transform.position.y, 0f));
        this.originalClickPointOffsetFromRoot = new Vector2(vector.x, vector.y) - this.originalClickPoint;
    }

    public void AttemptObjectSelectionPrincess(ObjectForDraw target)
    {
        if (!target.IsInASelectableState())
        {
            return;
        }
        if (this.activeObject != null && this.activeObject != target)
        {
            this.PerformActiveObjectDeselectionPrincess(false);
        }
        this.activeObject = target;
        this.CaptureOriginalClickPointAndOffsetPrincess();
        this.activeObject.Select();
        this.tapTimer.Reset();
        this.State = ObjectMovementStateID.ObjectSelected_MouseDown;
    }

    public static bool MainActionInsideSelectionAreaPrincess()
    {
        return GameInputManager.MouseFingerXPercent >= 0.035f && GameInputManager.MouseFingerXPercent <= 0.965f && GameInputManager.MouseFingerYPercent >= 0.035f && GameInputManager.MouseFingerYPercent <= 0.965f;
    }

    public static bool HandleMainActionDownInsideSelectionAreaPrincess()
    {
        return GameInputManager.IsPressedDownPrincess(KeyInputID.MainAction) && MasterObjectMover.MainActionInsideSelectionAreaPrincess();
    }

    public void CheckTouchDeadLandCollisionPrincess()
    {
        GridCell cellUnderCursor = GameInputManager.CellUnderCursor;
        if (cellUnderCursor == null)
        {
            return;
        }
        if (!cellUnderCursor.Dead)
        {
            return;
        }
        if (cellUnderCursor.DeathComponent.HasImmunityPrincess())
        {
            //cellUnderCursor.DeathComponent.AttemptDisplayMeterFromPlayerTouchPrincess();
        }
    }

    public void NoOperationLateUpdatePrincess()
    {
        this.tapTimer.Update(Time.deltaTime);
        if (MasterObjectMover.HandleMainActionDownInsideSelectionAreaPrincess())
        {
            ObjectForDraw objectUnderCursor = GameInputManager.ObjectUnderCursor;
            if (objectUnderCursor)
            {
                this.AttemptObjectSelectionPrincess(objectUnderCursor);
            }
            this.CheckTouchDeadLandCollisionPrincess();
        }
    }

    public bool CheckActiveObjectValidityPrincess()
    {
        if (this.activeObject == null || this.activeObject.IsDying())
        {
            this.PerformActiveObjectDeselectionPrincess(false);
            this.State = ObjectMovementStateID.None;
            return false;
        }
        return true;
    }

    public bool MovedFarEnoughToInitiateDragPrincess()
    {
        Vector3 a = new Vector3((float)GameInputManager.MouseFingerX, (float)GameInputManager.MouseFingerY, 0f);
        Vector3 b = new Vector3(this.originalClickPoint.x, this.originalClickPoint.y, 0f);
        float screenPixelAmount = Vector3.Distance(a, b);
        float num = GameInputManager.ConvertScreenToInchesPrincess(screenPixelAmount);
        return num > 0.1f;
    }

    public void AttemptObjectDragInitiationPrincess()
    {
        if (this.MovedFarEnoughToInitiateDragPrincess())
        {
            this.State = ObjectMovementStateID.ObjectDragging;
        }
    }

    public bool DetectDoubleTapOnPrincess(ObjectForDraw tapped)
    {
        bool result = false;
        if (this.tapTimer.Done)
        {
            this.numTaps = 0;
        }
        else if (this.numTaps == 2)
        {
            tapped.DoubleTapped();
            result = true;
            this.numTaps = 0;
        }
        this.tapTimer.Reset();
        return result;
    }

    public void HandleObjectSelectedMouseDownLateUpdatePrincess()
    {
        if (!this.CheckActiveObjectValidityPrincess())
        {
            return;
        }

        //this.DisplayAdOnMouseDownPrincess();

        this.tapTimer.Update(Time.deltaTime);
        if (GameInputManager.IsPressedDownPrincess(KeyInputID.MainAction))
        {
            if (this.activeObject.IsInADraggableState())
            {
                this.AttemptObjectDragInitiationPrincess();
            }
        }
        else
        {
            this.State = ObjectMovementStateID.ObjectSelected_NoMouseDown;
            if (!this.MovedFarEnoughToInitiateDragPrincess() && !this.tapTimer.Done)
            {
                this.numTaps++;
                bool flag = false;
                if (this.activeObject == this.previousObject)
                {
                    flag = this.DetectDoubleTapOnPrincess(this.activeObject);
                }
                if (!flag)
                {

                    this.numTaps = 1;
                    this.activeObject.Tapped();

                }
                this.tapTimer.Reset();
            }
        }
    }

    public void ResetTapCountAndTimerPrincess()
    {
        this.numTaps = 0;
        this.tapTimer.Reset();
    }

    public void HandleObjectSelectedNoMouseDownLateUpdatePrincess()
    {
        this.tapTimer.Update(Time.deltaTime);
        if (!this.CheckActiveObjectValidityPrincess())
        {
            return;
        }
        if (GameInputManager.IsPressedDownPrincess(KeyInputID.MainAction))
        {
            ObjectForDraw activeObject = this.activeObject;
            ObjectForDraw drawnObject = (!MasterObjectMover.HandleMainActionDownInsideSelectionAreaPrincess()) ? null : GameInputManager.ObjectUnderCursor;
            if (activeObject == drawnObject)
            {
                this.CaptureOriginalClickPointAndOffsetPrincess();
                this.State = ObjectMovementStateID.ObjectSelected_ReclickMouseDownOnSameObject;
            }
            else if (!MasterObjectMover.MouseDownOnNewObjectAlwaysSelectsNewObject && this.activeObject.IsAMonster && drawnObject != null && !drawnObject.IsAMonster)
            {
                this.State = ObjectMovementStateID.MonsterSelected_ReclickMouseDownOnNonMonster;
                this.playerRecentlyDraggedOrScaled = false;
                this.ResetTapCountAndTimerPrincess();
            }
            else if (drawnObject != null && drawnObject.IsInASelectableState())
            {
                if (MasterObjectMover.MouseDownOnNewObjectAlwaysSelectsNewObject)
                {
                    this.AttemptObjectSelectionPrincess(drawnObject);
                }
                else
                {
                    this.State = ObjectMovementStateID.ObjectSelected_ReclickMouseDownOnNewSelectableObject;
                }
                this.playerRecentlyDraggedOrScaled = false;
                this.ResetTapCountAndTimerPrincess();
            }
            else
            {
                this.State = ObjectMovementStateID.ObjectSelected_ReclickMouseDownOnNothingSelectable;
                this.playerRecentlyDraggedOrScaled = false;
                this.ResetTapCountAndTimerPrincess();
            }
        }
    }

    public void HandleObjectSelectedReclickMouseDownOnSameObjectLateUpdate()
    {
        this.tapTimer.Update(Time.deltaTime);
        if (GameInputManager.IsPressedDownPrincess(KeyInputID.MainAction))
        {
            if (this.activeObject.IsInADraggableState())
            {
                this.AttemptObjectDragInitiationPrincess();
            }
        }
        else
        {
            if (!this.tapTimer.Done)
            {
                this.numTaps++;
                if (!this.DetectDoubleTapOnPrincess(this.activeObject))
                {
                    this.activeObject.Tapped();
                }
            }
            this.PerformActiveObjectDeselectionPrincess(false);
        }
    }

    public void HandleObjectSelectedReclickMouseDownOnNothingSelectableMouseReleasedTryRelocateObjectLateUpdatePrincess()
    {
        Vector3 vector = CameraControl.Camera.ScreenToWorldPoint(new Vector3((float)GameInputManager.MouseFingerX, (float)GameInputManager.MouseFingerY, 0f));
        Vector2 vector2 = GridCellsMgr.MapWorldToGrid(new Vector2(vector.x, vector.y));
        int xIndex = (int)vector2.x;
        int yIndex = (int)vector2.y;
        if (!GridCellsMgr.Instance.WithinBoundsPrincess(xIndex, yIndex, true))
        {
            this.State = ObjectMovementStateID.ObjectSelected_NoMouseDown;
            this.ResetTapCountAndTimerPrincess();
            return;
        }
        if (this.activeObject.RequiresCellPlacement)
        {
            MetaCell metaCell_CenteredOn = GridCellsMgr.Instance.GetMetaCell_CenteredOn(vector.x, vector.y, this.activeObject, false);
            if (this.activeObject.IsInADraggableState() && metaCell_CenteredOn.CanBeOccupiedBy(this.activeObject) && !metaCell_CenteredOn.IsFullyOccupiedBy(this.activeObject, true))
            {
                this.activeObject.RefreshDragOrClickTargetCellPrincess(metaCell_CenteredOn, true);
                if (this.activeObject.State == MatchStateID.SwoopingToCell)
                {
                    this.activeObject.userDirectedOnGridSwoop = true;
                }
                this.PerformActiveObjectDeselectionPrincess(false);
                this.State = ObjectMovementStateID.None;
            }
            else
            {
                this.PerformActiveObjectDeselectionPrincess(false);
                this.State = ObjectMovementStateID.None;
                this.ResetTapCountAndTimerPrincess();
            }
        }
        else
        {
            if (this.activeObject.IsInADraggableState() && this.activeObject.DraggingIsMovableMOMPrincess())
            {
                this.activeObject.PerformSwoopOffGridToPrincess(vector.x, vector.y, true, true);
            }
            this.PerformActiveObjectDeselectionPrincess(false);
            this.State = ObjectMovementStateID.None;
        }
    }

    public void HandleObjectSelectedReclickMouseDownOnNothingSelectableLateUpdatePrincess()
    {
        if (!this.CheckActiveObjectValidityPrincess())
        {
            return;
        }
        if (!GameInputManager.IsPressedDownPrincess(KeyInputID.MainAction))
        {
            if (this.playerRecentlyDraggedOrScaled)
            {
                this.playerRecentlyDraggedOrScaled = false;
                this.State = ObjectMovementStateID.ObjectSelected_NoMouseDown;
                this.ResetTapCountAndTimerPrincess();
            }
            else
            {
                this.HandleObjectSelectedReclickMouseDownOnNothingSelectableMouseReleasedTryRelocateObjectLateUpdatePrincess();
            }
        }
    }

    public void HandleObjectSelectedReclickMouseDownAndUpOnNewSelectableObjectLateUpdatePrincess()
    {
        ObjectForDraw objectUnderCursor = GameInputManager.ObjectUnderCursor;
        if (objectUnderCursor == null || objectUnderCursor == this.activeObject)
        {
            this.playerRecentlyDraggedOrScaled = false;
            this.State = ObjectMovementStateID.ObjectSelected_NoMouseDown;
            this.ResetTapCountAndTimerPrincess();
            return;
        }
        bool flag = false;
        if (objectUnderCursor.Definition.Draggable && this.activeObject.Definition.RequiresCellPlacement && objectUnderCursor.Definition.RequiresCellPlacement)
        {
            flag = this.activeObject.AttemptSwapObjectWithOrMatchOverlapPrincess(objectUnderCursor);
        }
        if (flag)
        {
            this.PerformActiveObjectDeselectionPrincess(false);
            this.State = ObjectMovementStateID.ObjectSwapTriggered_MouseStillDown;
        }
        else
        {
            this.AttemptObjectSelectionPrincess(objectUnderCursor);
        }
    }

    public void HandleObjectSelectedReclickMouseDownOnNewSelectableObjectLateUpdatePrincess()
    {
        if (!this.CheckActiveObjectValidityPrincess())
        {
            return;
        }
        if (!GameInputManager.IsPressedDownPrincess(KeyInputID.MainAction))
        {
            if (this.playerRecentlyDraggedOrScaled)
            {
                this.playerRecentlyDraggedOrScaled = false;
                this.State = ObjectMovementStateID.ObjectSelected_NoMouseDown;
                this.ResetTapCountAndTimerPrincess();
            }
            else if (MasterObjectMover.AllowTapTapToSwapObjects)
            {
                this.HandleObjectSelectedReclickMouseDownAndUpOnNewSelectableObjectLateUpdatePrincess();
            }
            else
            {
                ObjectForDraw objectUnderCursor = GameInputManager.ObjectUnderCursor;
                if (objectUnderCursor == null)
                {
                    this.State = ObjectMovementStateID.ObjectSelected_ReclickMouseDownOnNothingSelectable;
                }
                else
                {
                    this.AttemptObjectSelectionPrincess(objectUnderCursor);
                }
            }
        }
    }

    public void HandleObjectDraggingLateUpdatePrincess()
    {
        if (!this.CheckActiveObjectValidityPrincess())
        {
            return;
        }
        if (GameInputManager.IsPressedDownPrincess(KeyInputID.MainAction))
        {
            Vector3 vector = CameraControl.Camera.ScreenToWorldPoint(new Vector3((float)GameInputManager.MouseFingerX, (float)GameInputManager.MouseFingerY, 0f));
            if (this.useOffsetMousePosition)
            {
                vector = CameraControl.Camera.ScreenToWorldPoint(new Vector3((float)this.OffsetMouseX, (float)this.OffsetMouseY, 0f));
            }
            bool canMove = true;
            if (this.activeObject.RequiresCellPlacement && GridCellsMgr.Instance.WithinWorldSpaceBoundsPrincess(vector.x, vector.y, true))
            {
                MetaCell metaCell_CenteredOn = GridCellsMgr.Instance.GetMetaCell_CenteredOn(vector.x, vector.y, this.activeObject, false);
                if (canMove)
                {

                    this.activeObject.RefreshDragOrClickTargetCellPrincess(metaCell_CenteredOn);
                    if (this.activeObject.State == MatchStateID.SwoopingToCell)
                    {
                        this.activeObject.userDirectedOnGridSwoop = true;
                    }
                }

            }
            if (canMove)
            {
                if (this.activeObject.DraggingIsMovableMOMPrincess())
                {
                    Vector2 dragDelta = new Vector2(vector.x - this.activeObject.X, vector.y - this.activeObject.Y);
                    this.activeObject.DefineRootPositionPrincess(vector.x, vector.y);
                    this.activeObject.OnDrag(dragDelta);
                }
            }
        }
        else
        {
            this.activeObject.PlayerDismountedFromDragPrincess();
            this.PerformActiveObjectDeselectionPrincess(false);

        }
    }

    public static bool CheckIfSelectedObjectAndClickOnDifferentObjectPrincess()
    {
        return !(MasterObjectMover.Instance.activeObject == null) && GameInputManager.IsPressedDownPrincess(KeyInputID.MainAction) && GameInputManager.ObjectUnderCursor != MasterObjectMover.Instance.activeObject;
    }

    public void CustomLateUpdatePrincess()
    {
        if (this.ignoringInputUntilMouseUp)
        {
            if (!GameInputManager.IsPressedDownPrincess(KeyInputID.MainAction))
            {
                this.ignoringInputUntilMouseUp = false;
            }
            return;
        }
        if (GameMgr.IsSimulationPaused())
        {
            return;
        }
        if (CameraControl.Instance.IsCameraDraggingPrincess() || GameInputManager.m_fingerCount > 1)
        {
            this.playerRecentlyDraggedOrScaled = true;
            return;
        }
        if (this.activeObject == null && CameraControl.Instance.IsCameraInPreDragBufferPrincess())
        {
            return;
        }
        if (this.State == ObjectMovementStateID.None)
        {
            this.NoOperationLateUpdatePrincess();
        }
        else if (this.State == ObjectMovementStateID.ObjectSelected_MouseDown)
        {
            this.HandleObjectSelectedMouseDownLateUpdatePrincess();
        }
        else if (this.State == ObjectMovementStateID.ObjectSelected_NoMouseDown)
        {
            this.HandleObjectSelectedNoMouseDownLateUpdatePrincess();
        }
        else if (this.State == ObjectMovementStateID.ObjectSwapTriggered_MouseStillDown)
        {
            //this.HandleObjectSwapTriggeredMouseStillDownLateUpdatePrincess();
        }
        else if (this.State == ObjectMovementStateID.ObjectSelected_ReclickMouseDownOnSameObject)
        {
            this.HandleObjectSelectedReclickMouseDownOnSameObjectLateUpdate();
        }
        else if (this.State == ObjectMovementStateID.ObjectSelected_ReclickMouseDownOnNothingSelectable)
        {
            this.HandleObjectSelectedReclickMouseDownOnNothingSelectableLateUpdatePrincess();
        }
        else if (this.State == ObjectMovementStateID.ObjectSelected_ReclickMouseDownOnNewSelectableObject)
        {
            this.HandleObjectSelectedReclickMouseDownOnNewSelectableObjectLateUpdatePrincess();
        }
        else if (this.State == ObjectMovementStateID.ObjectDragging)
        {
            this.HandleObjectDraggingLateUpdatePrincess();
        }
    }
}
