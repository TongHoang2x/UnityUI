using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubEventDragTouch : MonoBehaviour
{
    [SerializeField] RectTransform uiRectransfrom;
    [SerializeField] float stepValue = 2;                   // buoc nhay thay doi gia tri
    Vector2 init_SizeDelta, init_anchoredPosition;          // gia tri ban dau
    [SerializeField] float minHeightSizeDelta = 110;             // thu nho den

    private void Awake()
    {
        uiRectransfrom.GetComponent<RectTransform>();
        if (uiRectransfrom == null) { return; }

        // Save valua start
        init_anchoredPosition = uiRectransfrom.anchoredPosition;      // left, pos Y, pos Z trectransfrom
        init_SizeDelta = uiRectransfrom.sizeDelta;                    // Height rectransfrom        
    }

    void Start()
    {
        // Sub event
        EventDrag._EventDrag.ActionDragUp += ScaleUp;
        EventDrag._EventDrag.ActionDragDown += ScaleDown;
        EventDrag._EventDrag.AtionDragEnd += EndDragScrollDown;
    }

    private void OnDestroy()
    {
        // unregister event
        EventDrag._EventDrag.ActionDragUp -= ScaleUp;
        EventDrag._EventDrag.ActionDragDown -= ScaleDown;
        EventDrag._EventDrag.AtionDragEnd -= EndDragScrollDown;
    }

    // Drag xuong - phong to ui
    void ScaleDown()
    {
        Debug.Log("keo dan ui");

        ScaleUpHeight(stepValue);
        ScaleUpPosY(stepValue);
    }

    // Drag len - thu nho
    void ScaleUp()
    {
        Debug.Log("Thu nho ui");

        // heigh <= 110 stop
        if (uiRectransfrom.sizeDelta.y <= minHeightSizeDelta)
        {
            ScaleToMin();
            return;
        }

        // // Height
        ScaleDownHeight(stepValue);

        // // Pos Y
        ScaleDownPosY(stepValue);
    }

    // dung drag
    void EndDragScrollDown()
    {
        // scale lon hon gia tri khoi tao
        if (uiRectransfrom.sizeDelta.y > init_SizeDelta.y)
        {
            ScaleToTarget();
        }

    }

    // scalte den vi tri muon khi dung drag
    void ScaleToTarget()
    {
        // Height
        uiRectransfrom.sizeDelta = init_SizeDelta;
        // // Pos Y
        uiRectransfrom.anchoredPosition = init_anchoredPosition;
    }

    // min state UI
    void ScaleToMin()
    {
        // Height
        uiRectransfrom.sizeDelta = new Vector2(uiRectransfrom.sizeDelta.x, minHeightSizeDelta);
        // // Pos Y
        uiRectransfrom.anchoredPosition = new Vector2(uiRectransfrom.anchoredPosition.x, -minHeightSizeDelta / 2);
    }

    // tang chieu cao
    void ScaleUpHeight(float value)
    {
        Vector2 newSizeDelta = uiRectransfrom.sizeDelta;
        newSizeDelta.y += value;
        uiRectransfrom.sizeDelta = newSizeDelta;
    }

    // tang pos Y
    void ScaleUpPosY(float value)
    {
        Vector2 newPosY = uiRectransfrom.anchoredPosition;
        newPosY.y += -value / 2;
        uiRectransfrom.anchoredPosition = newPosY;
    }

    // giam chieu cao
    void ScaleDownHeight(float value)
    {
        // Vector2 newSizeDelta = uiRectransfrom.sizeDelta;
        // newSizeDelta.y -= value;
        // uiRectransfrom.sizeDelta = newSizeDelta;
    }

    // giam Pos Y
    void ScaleDownPosY(float value)
    {
        Vector2 newPosY = uiRectransfrom.anchoredPosition;
        newPosY.y -= value;
        uiRectransfrom.anchoredPosition = newPosY;
    }

}