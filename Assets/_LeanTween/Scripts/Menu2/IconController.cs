using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{    
    /// <summary>
    /// Icon_SVG image co rectransfrom center
    /// thay doi pos x, pos y
    /// </summary>
    public void StartJumping(){
        transform.LeanMoveLocal(new Vector2(3, -250), 0.5f)
        .setEaseOutQuart()
        .setLoopPingPong();
    }
}
