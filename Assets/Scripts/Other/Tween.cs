using System;
using UnityEngine;
using UnityEngine.Serialization;

public static class Tween
{
    public static void StopTweensOn(ObjectForDraw drawnObject)
    {
        if (drawnObject.gameObject != null)
        {
            iTween.Stop(drawnObject.gameObject);
        }
        if (drawnObject.LocalPositionAnimTarget != null)
        {
            iTween.Stop(drawnObject.LocalPositionAnimTarget);
        }
        drawnObject.RecoverLocalPositionScaleRotationPrincess();
    }

    public static void ShakeCamera_VerticalImpact()
    {
        Tween.ShakeCamera_VerticalImpact(0.075f);
    }

    public static void ShakeCamera_VerticalImpact(float amount)
    {
        GameObject gameObject = CameraControl.Camera.gameObject;
        if (CameraControl.ShakeHandler != null)
        {
            gameObject = CameraControl.ShakeHandler.gameObject;
        }
        iTween.ShakePosition(gameObject, new Vector3(0f, amount, 0f), 0.5f);
    }

    public static void EaseBackToOriginalScale(ObjectForDraw drawnObject)
    {
        Tween.ScaleTo(drawnObject, "EaseScaleHome", 0.2f, drawnObject.restingScale.x, drawnObject.restingScale.y, iTween.LoopType.none);
    }

    public static void ScaleTo(ObjectForDraw drawnObject, string animationName, float time, float targetScaleX, float targetScaleY, iTween.LoopType loopType)
    {
        iTween.ScaleTo(drawnObject.gameObject, iTween.Hash(new object[]
        {
            "name",
            animationName,
            "islocal",
            true,
            "time",
            time,
            "x",
            targetScaleX,
            "y",
            targetScaleY,
            "looptype",
            loopType,
            "EaseType",
            iTween.EaseType.easeOutQuad
        }));
    }

    public static void MoveTo(GameObject gameObject, string animationName, bool isLocal, float time, float x, float y)
    {
        iTween.MoveTo(gameObject, iTween.Hash(new object[]
        {
            "name",
            animationName,
            "islocal",
            isLocal,
            "time",
            time,
            "x",
            x,
            "y",
            y,
            "EaseType",
            iTween.EaseType.easeOutQuad
        }));
    }

    public static void MoveTo(ObjectForDraw drawnObject, string animationName, float time, float x, float y)
    {
        Tween.MoveTo(drawnObject.LocalPositionAnimTarget, animationName, true, time, x, y);
    }

    public static void EaseBackToOriginalPosition(ObjectForDraw drawnObject)
    {
        Tween.MoveTo(drawnObject, "EasePositionHome", 0.2f, drawnObject.originalPosition.x, drawnObject.originalPosition.y);
    }

    public static void MoveBy(ObjectForDraw drawnObject, string animationName, float time, float xDisplacement, float yDisplacement, iTween.LoopType loopType)
    {
        Tween.MoveBy(drawnObject, animationName, time, xDisplacement, yDisplacement, loopType, iTween.EaseType.easeOutQuad);
    }

    public static void MoveBy(GameObject gameObject, string animationName, float time, float xDisplacement, float yDisplacement, iTween.LoopType loopType, iTween.EaseType easeType)
    {
        iTween.MoveBy(gameObject, iTween.Hash(new object[]
        {
            "name",
            animationName,
            "islocal",
            true,
            "time",
            time,
            "x",
            xDisplacement,
            "y",
            yDisplacement,
            "looptype",
            loopType,
            "EaseType",
            easeType
        }));
    }

    public static void MoveBy(ObjectForDraw drawnObject, string animationName, float time, float xDisplacement, float yDisplacement, iTween.LoopType loopType, iTween.EaseType easeType,bool hide = false)
    {
        iTween.MoveBy(drawnObject.LocalPositionAnimTarget, iTween.Hash(new object[]
        {
            "name",
            animationName,
            "islocal",
            true,
            "time",
            time,
            "x",
            xDisplacement,
            "y",
            yDisplacement,
            "looptype",
            loopType,
            "EaseType",
            easeType
        }));
}

    public static bool ObjectHasScaleAnimPlaying(ObjectForDraw drawnObject)
    {
        return iTween.CountAnyWithStringInFunctionCallName(drawnObject.gameObject, "Scale") > 0;
    }

    public static void PunchScale(ObjectForDraw drawnObject, string animationName, float time, float xGrowth, float yGrowth, bool resetToRestingScaleFirst)
    {
        if (drawnObject == null)
        {
            return;
        }
        xGrowth *= drawnObject.restingScale.x;
        yGrowth *= drawnObject.restingScale.y;
        if (resetToRestingScaleFirst)
        {
            drawnObject.transform.localScale = drawnObject.restingScale;
        }
        iTween.PunchScale(drawnObject.gameObject, iTween.Hash(new object[]
        {
            "name",
            animationName,
            "islocal",
            true,
            "time",
            time,
            "x",
            xGrowth,
            "y",
            yGrowth
        }));
    }

    public static void PunchScale(ObjectForDraw drawnObject, string animationName, bool resetToRestingScaleFirst)
    {
        Tween.PunchScale(drawnObject, animationName, 1.5f, 0.5f, 0.5f, resetToRestingScaleFirst);
    }

    public static void PunchScale(ObjectForDraw drawnObject, string animationName, float xyGrowth, bool resetToRestingScaleFirst)
    {
        Tween.PunchScale(drawnObject, animationName, 1.5f, xyGrowth, xyGrowth, resetToRestingScaleFirst);
    }

    public static void RotateBy(GameObject gameObject, string animationName, float time, float rotationDegrees, iTween.LoopType loopType, iTween.EaseType easeType)
    {
        rotationDegrees /= 360f;
        iTween.RotateBy(gameObject, iTween.Hash(new object[]
        {
            "name",
            animationName,
            "islocal",
            true,
            "time",
            time,
            "z",
            rotationDegrees,
            "looptype",
            loopType,
            "EaseType",
            easeType
        }));
    }

    public static void RotateBy(ObjectForDraw drawnObject, string animationName, float time, float rotationDegrees, iTween.LoopType loopType, iTween.EaseType easeType)
    {
        rotationDegrees /= 360f;
        iTween.RotateBy(drawnObject.gameObject, iTween.Hash(new object[]
        {
            "name",
            animationName,
            "islocal",
            true,
            "time",
            time,
            "z",
            rotationDegrees,
            "looptype",
            loopType,
            "EaseType",
            easeType
        }));
    }

    public static void ScaleBy(GameObject gameObject, string animationName, float time, float scaleMultiplier, iTween.LoopType loopType, iTween.EaseType easeType)
    {
        iTween.ScaleBy(gameObject, iTween.Hash(new object[]
        {
            "name",
            animationName,
            "islocal",
            true,
            "time",
            time,
            "x",
            scaleMultiplier,
            "y",
            scaleMultiplier,
            "looptype",
            loopType,
            "EaseType",
            easeType
        }));
    }

    public static void ScaleBy(ObjectForDraw drawnObject, string animationName, float time, float scaleMultiplier, iTween.LoopType loopType, iTween.EaseType easeType)
    {
        Tween.ScaleBy(drawnObject.gameObject, animationName, time, scaleMultiplier, loopType, easeType);
    }

    public static void ShakePosition(GameObject obj, string animationName, float xAmount, float yAmount)
    {
        iTween.ShakePosition(obj, iTween.Hash(new object[]
        {
            "name",
            animationName,
            "islocal",
            true,
            "time",
            0.5f,
            "x",
            xAmount,
            "y",
            yAmount
        }));
    }

    public static void EnableBaseAnims(ObjectForDraw drawnObject)
    {
        if (drawnObject.BaseAnimComponent != null)
        {
            drawnObject.BaseAnimComponent.EnableAnimationPrincess();
        }
    }

    public static void StopBaseAnims(ObjectForDraw drawnObject)
    {
        if (drawnObject.BaseAnimComponent != null)
        {
            drawnObject.BaseAnimComponent.StopAnimationPrincess();
        }
    }

    public static void ScaleBy(ObjectForDraw drawnObject, string animationName, float time, float scaleMultiplier, iTween.LoopType loopType)
    {
        Tween.ScaleBy(drawnObject, animationName, time, scaleMultiplier, loopType, iTween.EaseType.easeOutQuad);
    }

    public static void DisableBaseAnims(ObjectForDraw drawnObject)
    {
        if (drawnObject.BaseAnimComponent != null)
        {
            drawnObject.BaseAnimComponent.DisableAnimationPrincess();
        }
    }

    public static void ScaleTo(GameObject gameObject, string animationName, float time, float targetScaleX, float targetScaleY, iTween.LoopType loopType)
    {
        iTween.ScaleTo(gameObject, iTween.Hash(new object[]
        {
            "name",
            animationName,
            "islocal",
            true,
            "time",
            time,
            "x",
            targetScaleX,
            "y",
            targetScaleY,
            "looptype",
            loopType,
            "EaseType",
            iTween.EaseType.easeOutQuad
        }));
    }

    public static void PunchPosition(GameObject gameObject, string animationName, float time, float x, float y, iTween.LoopType loopType)
    {
        iTween.PunchPosition(gameObject, iTween.Hash(new object[]
        {
            "name",
            animationName,
            "time",
            time,
            "x",
            x,
            "y",
            y,
            "looptype",
            loopType
        }));
    }
}
