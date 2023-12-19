using System;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventScrollSub : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Item cua 1 scrollivew. Co 2 obj top, down. khi drag obj top hien ra dc obj down
    // Lang event khi scrollview cha
    // Gan script cho item 
    public Transform topView;
    private Vector3 mouseStrartPos;
    private Vector3 topViewStartPos;
    Vector3 distance; // khoang cach drag
    public float newPosX;   // vi tri drag xong se dua top den
    bool horizontalDrag = false; // trang thai drag ngang
    bool veticalDrag = false; // trang thai drag doc

    float horizontalDragMinDistance = 30f; // khoang cach khi drag de phat hien la drag ngang
    float verticalDragMinDistance = 8f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        mouseStrartPos = Input.mousePosition;
        topViewStartPos = topView.localPosition;

        // Publisher event: Khi drag item thi tra lai vi tri cac item khac da bi drag
        EventsScroll._EventScroll.EventOnDragHideHorizontal(GetInstanceID());

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

        // khi drag ngang se dua top den vi tri moi
        if (horizontalDrag)
        {
            //newPosX = topViewStartPos.x + Mathf.Max(0, distance.x);
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
            if (distance.x > (newPosX / 2))
            {
                // show ra item down
                // Sub: Nhan su kien scrollview thi thuc hien ham 
                EventsScroll._EventScroll.OnScrollStart += HideItemDownWhenSCroll;
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

    private void Start()
    {
        // lay ve chieu dai item
        var rectItem = GetComponent<RectTransform>();
        float itemWidth = rectItem.rect.width / 2;
        newPosX = MathF.Round(itemWidth);

        // Sub event: 
        EventsScroll._EventScroll.OnDragHideHorizontal += HideItemDown;
    }

    // huy cac dang ky
    private void OnDestroy()
    {
        EventsScroll._EventScroll.OnScrollStart -= HideItemDownWhenSCroll;
        EventsScroll._EventScroll.OnDragHideHorizontal -= HideItemDown;
    }

    // Dua topview ve vi tri ban dau khi scrollview
    void HideItemDownWhenSCroll(){
        Debug.Log("Dowhenscrollstart");
        topView.localPosition = topViewStartPos;
    }

    // Dua topview ve vi tri ban dau khi item khac minh bi drag
    void HideItemDown(int id)
    {
        if(id == GetInstanceID() ) return;

        Debug.Log("Drag horizontal");
        topView.localPosition = topViewStartPos;
    }

    public void GetInstanceId(){
        Debug.Log("InstanceId: " + GetInstanceID());
    }

    public void GetInstanceId_2(){
        Debug.Log("InstanceId 2: " + GetInstanceID());
    }

}
