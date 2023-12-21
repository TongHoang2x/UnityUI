using UnityEngine;
using UnityEngine.EventSystems;

public class PubEventScroll : MonoBehaviour, IEndDragHandler, IDragHandler
{
    // gan cho 1 scrollview
    // khi scroll theo y thi phat di su kien cho obj dang ky

    [SerializeField] float dragThreshould;   // bien drag man hinh
    [SerializeField] float distance = 30f;   // khoang cach drag 
    private void Start()
    {
        dragThreshould = Screen.height / distance;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EventDrag._EventDrag.Call_ActionDragEnd();
    }

    public void OnDrag(PointerEventData eventData)
    {
        ProcessDrag(eventData);
    }

    // xu ly khi drag
    void ProcessDrag(PointerEventData eventData){
        //if(Mathf.Abs( drag end postion - drag start postion > dragthreshould ))
        if (Mathf.Abs(eventData.position.y - eventData.pressPosition.y) > dragThreshould)
        {
            if(eventData.position.y > eventData.pressPosition.y){
                Debug.Log("Drag len");

                // Publisher event drag up
                EventDrag._EventDrag.Call_ActionDragUp();

            }else{
                Debug.Log("Drag xuong");

                EventDrag._EventDrag.Call_ActionDragDown();
            }
        }
        else
        {
            Debug.Log("Drag nho qua");
        }
    }
}

