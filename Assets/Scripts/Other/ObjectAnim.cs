using System;
using UnityEngine;
using UnityEngine.Serialization;

public static class ObjectAnim
{
    public static Vector2 pushLeft = GridCellsMgr.MapGridToWorld(-0.3f, 0f);
    public static Vector2 pushRight = GridCellsMgr.MapGridToWorld(0.3f, 0f);

    public static void EndPushedAnimationPrincess(ObjectForDraw pushedObj)
    {
        if (pushedObj != null)
        {
            Tween.EaseBackToOriginalPosition(pushedObj);
        }
    }

    public static void StartPushedAnimationPrincess(ObjectForDraw pushedObj, MetaCell pushZone)
    {
        if (pushedObj.metaCell == null || pushedObj.metaCell.OverlapsLeftwardOn(pushZone))
        {
            Tween.MoveBy(pushedObj, "Push", 0.3f, ObjectAnim.pushLeft.x, ObjectAnim.pushLeft.y, iTween.LoopType.none);
        }
        else
        {
            Tween.MoveBy(pushedObj, "Push", 0.3f, ObjectAnim.pushRight.x, ObjectAnim.pushRight.y, iTween.LoopType.none);
        }
    }

    public static void StartNewObjectAppearAnimationPrincess(ObjectForDraw drawnObject, bool resetToRestingScaleFirst)
    {
        if (Tween.ObjectHasScaleAnimPlaying(drawnObject))
        {
            return;
        }
        Tween.PunchScale(drawnObject, "NewObjectAppear_Scale_ObjectAnim", resetToRestingScaleFirst);
    }

    public static void StartNewObjectAppearAnimationPrincess(ObjectForDraw drawnObject)
    {
        ObjectAnim.StartNewObjectAppearAnimationPrincess(drawnObject, true);
    }

    public static void StartGrabbedAnimationPrincess(ObjectForDraw drawnObject)
    {
        if (Tween.ObjectHasScaleAnimPlaying(drawnObject))
        {
            return;
        }
        Tween.PunchScale(drawnObject, "Grabbed_ObjectAnim", 0.2f, true);
    }

    public static void EndPotentialMatchAnimationPrincess(ObjectForDraw partner)
    {
        iTween.StopByName(partner.gameObject, "PotentialMatch_ObjectAnim");
        iTween.StopByName(partner.LocalPositionAnimTarget, "PotentialMatch_ObjectAnim");
        Tween.EaseBackToOriginalPosition(partner);
        Tween.EaseBackToOriginalScale(partner);
    }

    public static void EndPotentialMatchAnimationOnOwnerPrincess(ObjectForDraw owner)
    {
        Tween.EnableBaseAnims(owner);
    }

    public static void StopMoveAndScaleAnimation(GameObject movingObject)
    {
        // 停止特定的动画
        iTween.StopByName(movingObject, "MoveAndScale_Animation");
    }

    public static void StartPotentialMatchAnimationPrincess(ObjectForDraw drawnObject, ObjectForDraw partner, MetaCell targetCell)
    {
        Vector2 a = (targetCell == null) ? drawnObject.Position2D : targetCell.Center;
        Vector2 a2 = a - partner.Position2D;
        a2.Normalize();
        a2 *= 0.4f;
        Tween.StopBaseAnims(partner);
        partner.RecoverLocalRotationPrincess();
        Tween.MoveBy(partner, "PotentialMatch_ObjectAnim", 0.5f, a2.x, a2.y, iTween.LoopType.pingPong);
        Tween.ScaleBy(partner, "PotentialMatch_ObjectAnim", 0.5f, 1.15f, iTween.LoopType.pingPong);
    }

    public static void StartRotationAnimation(GameObject rotatingObject, float rotationAngle = 30f, float duration = 2f)
    {
        // 先旋转到目标角度
        iTween.RotateTo(rotatingObject, iTween.Hash(
            "z", rotationAngle,
            "time", duration,
            "easetype", iTween.EaseType.easeInOutSine,
            "oncomplete", "OnRotateBack",  // 当旋转完成后，调用回调函数
            "oncompletetarget", rotatingObject // 确保回调在这个物体上调用
        ));
    }

    public static void StartMoveAndScaleAnimation(GameObject movingObject, Vector2 startPosition, Vector2 endPosition)
    {
        // 确保物体开始时在起始位置
        movingObject.transform.position = startPosition;

        // 计算移动的方向和距离
        Vector2 displacement = endPosition - startPosition;

        // 停止物体的基础动画（如果有的话）
        //Tween.StopBaseAnims(movingObject);

        // 执行平移动画，使用 pingPong 来回移动
        iTween.MoveTo(movingObject, iTween.Hash(
            "name", "MoveAndScale_Animation",
            "time", 2f,
            "x", endPosition.x,
            "y", endPosition.y,
            "looptype", iTween.LoopType.none,
            "easeType", iTween.EaseType.easeInOutQuad, // 可以根据需要调整缓动类型
            "oncomplete", "OnAnimationComplete" // 设置回调函数
        ));
    }

    public static void StartPotentialMatchAnimationOnOwnerPrincess(ObjectForDraw owner)
    {
        Tween.DisableBaseAnims(owner);
        owner.RecoverLocalPositionScaleRotationPrincess();
    }

    public static void StartGreenArrowAppearAnimationPrincess(ObjectForDraw m_greenDownArrow)
    {
        Tween.ScaleTo(m_greenDownArrow.gameObject, "GreenArrowAppear", 0.25f, 0f, 0f, iTween.LoopType.none);
    }

    public static void StartDieFromTimeoutAnimationPrincess(ObjectForDraw drawnObject)
    {
        SpriteRenderer[] componentsInChildren = drawnObject.Root.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in componentsInChildren)
        {
            Tween.ScaleTo(spriteRenderer.gameObject, "DieFromTimeout", 0.6f, 0.001f, 0.001f, iTween.LoopType.none);
        }
    }

    public static void StartCellAppearsAnimationPrincess(int xCellIndex, int yCellIndex)
    {
        GridCell cell = GridCellsMgr.Instance.GetCell(xCellIndex, yCellIndex, false, false);
        if (cell == null)
        {
            return;
        }
        float y = 0.3f;
        Tween.PunchPosition(cell.gameObject, "CellAppear", 1.5f, 0f, y, iTween.LoopType.none);
        if (!cell.Occupied)
        {
            return;
        }
        Tween.PunchPosition(cell.Occupant.LocalPositionAnimTarget, "CellAppear_EntityOccupant", 1.5f, 0f, y, iTween.LoopType.none);
    }
}
