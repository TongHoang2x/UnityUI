using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingWindows : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    private void Start() {
        // bat dau se scale obj = 0
        transform.localScale = Vector2.zero;
    }

    /// <summary>
    /// Gan su kien cho nut button Open
    /// </summary>
    public void Open(){
        LeanTween.alphaCanvas(canvasGroup, 1f, 1f).setEase(LeanTweenType.easeInOutQuad);
        // khi open scale len 1
        transform.LeanScale(Vector2.one, 0.8f);
    }

    /// <summary>
    /// Gan su kien cho nut close
    /// </summary>
    public void Close(){
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }
}
