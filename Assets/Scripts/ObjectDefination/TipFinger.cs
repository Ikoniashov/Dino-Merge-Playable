using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipFinger : MonoBehaviour
{
    public void OnAnimationComplete()
    {
        GameMgr.Instance.tipFinger_0.SetActive(false);
        GameMgr.showTip = false;
    }

    public void OnRotateBack()
    {
        iTween.RotateTo(this.gameObject, iTween.Hash(
            "z", 0,  // 回到原角度
            "time", 0.5f, // 旋转时间
            "easetype", iTween.EaseType.easeInOutSine,
            "oncomplete", "OnAnimationComplete"
        ));
    }
}
