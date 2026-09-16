using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public static class UIExtensions
{
    public static void FadeGroup(this GameObject root, float endAlpha, float duration)
    {
        foreach (var image in root.GetComponentsInChildren<Image>(true))
        {
            image.DOFade(endAlpha, duration);
        }

        foreach (var text in root.GetComponentsInChildren<TMP_Text>(true))
        {
            text.DOFade(endAlpha, duration);
        }

        foreach (var text in root.GetComponentsInChildren<UnityEngine.UI.Text>(true))
        {
            text.DOFade(endAlpha, duration);
        }

        foreach (var text in root.GetComponentsInChildren<SpriteRenderer>(true))
        {
            text.DOFade(endAlpha, duration);
        }
    }
}