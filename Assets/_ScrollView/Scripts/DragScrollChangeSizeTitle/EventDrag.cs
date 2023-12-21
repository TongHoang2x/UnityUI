using System;
using UnityEngine;

public class EventDrag : MonoBehaviour
{
    public static EventDrag _EventDrag;
    private void Awake() {
        _EventDrag = this;
    }

    public event Action ActionDragUp;
    public event Action ActionDragDown;
    public event Action AtionDragEnd;

    public void Call_ActionDragUp(){
        if(ActionDragUp != null) ActionDragUp();
    }

    public void Call_ActionDragDown(){
        if(ActionDragDown != null) ActionDragDown();
    }

    public void Call_ActionDragEnd(){
        if(AtionDragEnd != null) AtionDragEnd();
    }
}
