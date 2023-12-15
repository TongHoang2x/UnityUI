using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset(){ Load_Components(); }

    protected virtual void Awake(){ Load_Components(); }

    protected virtual void Load_Components(){}
}
