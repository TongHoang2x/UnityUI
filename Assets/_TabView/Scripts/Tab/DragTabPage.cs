using UnityEngine;
using UnityEngine.EventSystems;

public class DragTabPage : AppMonoBehaviour, IEndDragHandler
{
    [SerializeField] int IdSub;               // id doi tuong phat sinh su kien
    [SerializeField] float dragThreshould;   // bien drag man hinh
    [SerializeField] float distance = 30f;   // khoang cach drag 
    private void Start()
    {
        dragThreshould = Screen.height / distance;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("drag end postion:" + eventData.position.y);
        //Debug.Log("drag start postion :" + eventData.pressPosition.y);

        //if(Mathf.Abs( drag end postion - drag start postion > dragthreshould ))
        if (Mathf.Abs(eventData.position.y - eventData.pressPosition.y) > dragThreshould)
        {
            if (eventData.position.y > eventData.pressPosition.y)
            {
                //Debug.Log("Len");
                DragEvents.MyDragEvents.OnDragUpTrigger(IdSub);
            }
            else
            {
                //Debug.Log("xuong");
                DragEvents.MyDragEvents.OnDragDownTrigger(IdSub);
            }
        }
        else
        {
            Debug.Log("Drag nho qua");
        }
    }
}
