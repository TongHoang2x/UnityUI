using UnityEngine;
using UnityEngine.EventSystems;

public class EventScrollPublisher : MonoBehaviour, IEndDragHandler
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
        //if(Mathf.Abs( drag end postion - drag start postion > dragthreshould ))
        if (Mathf.Abs(eventData.position.y - eventData.pressPosition.y) > dragThreshould)
        {
            // Goi phuong thuc o class event de publish event
            EventsScroll._EventScroll.EventOnScrollView();
        }
        else
        {
            //Debug.Log("Drag nho qua");
        }
    }

}
