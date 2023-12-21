using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTouch : MonoBehaviour
{
    Vector2 beginTouchPos;
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Began");
            beginTouchPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //Debug.Log("Moved");
            if (Input.GetTouch(0).position.y > beginTouchPos.y)
            {
                Debug.Log("MovedUp");

                // Publisher event drag up
                EventDrag._EventDrag.Call_ActionDragUp();
            }
            else if (Input.GetTouch(0).position.y < beginTouchPos.y)
            {
                Debug.Log("MovedDown");

                // Publisher event
                EventDrag._EventDrag.Call_ActionDragDown();
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Debug.Log("End");
            EventDrag._EventDrag.Call_ActionDragEnd();
        }
    }
}
