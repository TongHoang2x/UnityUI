using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    public Transform box;
    public CanvasGroup background;

    public void OnEnable() {
        background.alpha = 0;
        background.LeanAlpha(0.8f, 0.5f);

        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, 0.5f).setEaseInOutExpo().delay = 0.1f;
    }

    public void CloseDialog() {
        background.LeanAlpha(0, 0.5f);
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnCompleted);
    }

    void OnCompleted(){
        gameObject.SetActive(false);
    }
}
