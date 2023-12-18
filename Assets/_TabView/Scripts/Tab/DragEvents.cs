using System;
using UnityEngine;

public class DragEvents : MonoBehaviour
{
    public static DragEvents MyDragEvents;

    private void Awake() {
        MyDragEvents = this;
    }

    public event Action<int> EventOnDragUp;
    public event Action<int> EventOnDragDown;

    public void OnDragUpTrigger(int IdSub){
        if(EventOnDragUp != null) EventOnDragUp(IdSub);
    }

    public void OnDragDownTrigger(int IdSub){
        if(EventOnDragDown != null) EventOnDragDown(IdSub);
    }

}
