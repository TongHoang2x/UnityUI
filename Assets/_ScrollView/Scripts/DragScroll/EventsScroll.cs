using System;
using UnityEngine;

public class EventsScroll : MonoBehaviour
{
    // Dinh nghia cac event
    // Tao cach truy cap event bang Singleton

    // singletong
    public static EventsScroll _EventScroll;

    private void Awake() {
        _EventScroll = this;
    }

    // Dinh nghia event khi scrollview
    public event Action OnScrollStart;

    // Dinh nghia event khi drag horizontal
    public event Action<int> OnDragHideHorizontal;

    // Phuong thuc de class khac goi publish event
    public void EventOnScrollView(){
        if( OnScrollStart != null) OnScrollStart();
    }


     public void EventOnDragHideHorizontal(int id){
        if( OnDragHideHorizontal != null) OnDragHideHorizontal(id);
    }

}
