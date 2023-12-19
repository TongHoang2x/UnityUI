using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Drag de xoa item rown
    // script nay gan cho itemrow

    public Transform topView;

    private Vector3 mouseStrartPos;
    private Vector3 topViewStartPos;

    Vector3 distance;
    float newPosX;

    bool horizontalDrag = false;
    bool veticalDrag = false;

    float horizontalDragMinDistance = 30f;
    float verticalDragMinDistance = 8f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        mouseStrartPos = Input.mousePosition;
        topViewStartPos = topView.localPosition;



        // ExcuretHerachy phan cap thuc thi
        // Ta chuyen su kien drag len cho doi tuong cha. du lieu gui di la eventData, hanh dong la beginDragHandler
        ExecuteEvents.ExecuteHierarchy(transform.parent.gameObject, eventData, ExecuteEvents.beginDragHandler);

    }

    public void OnDrag(PointerEventData eventData)
    {
        distance = Input.mousePosition - mouseStrartPos;

        // phat hien keo ngang hay doc
        if (!horizontalDrag && !veticalDrag)
        {
            if (distance.x > horizontalDragMinDistance)
            {
                horizontalDrag = true;

                return;
            }
            else
            {
                if (Mathf.Abs(distance.y) > verticalDragMinDistance)
                {
                    veticalDrag = true;
                    return;
                }
            }
        }

        // keo ngang
        if (horizontalDrag)
        {
            newPosX = topViewStartPos.x + Mathf.Max(0, distance.x);
            topView.localPosition = new Vector3(newPosX, topViewStartPos.y, topViewStartPos.z);

        }
        else
        {
            // Ta chuyen su kien drag len cho doi tuong cha. du lieu gui di la eventData, hanh dong la dragHandler
            ExecuteEvents.ExecuteHierarchy(transform.parent.gameObject, eventData, ExecuteEvents.dragHandler);

        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // neu dung la keo ngang
        if (horizontalDrag)
        {
            distance = Input.mousePosition - mouseStrartPos;
            if (distance.x > 100f)
            {
                Destroy(gameObject);
            }
            else
            {
                topView.localPosition = topViewStartPos;
            }
        }

        // ket thuc drag
        horizontalDrag = veticalDrag = false;

        // Ta chuyen su kien drag len cho doi tuong cha. du lieu gui di la eventData, hanh dong la endDragHandler
        ExecuteEvents.ExecuteHierarchy(transform.parent.gameObject, eventData, ExecuteEvents.endDragHandler);

    }

}
