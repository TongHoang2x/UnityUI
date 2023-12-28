using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPanel : MonoBehaviour
{
    [SerializeField] Transform[] trans;

    [SerializeField] float witdScreen;

    // Start is called before the first frame update
    void Start()
    {        
        witdScreen = Screen.width;
        Debug.Log("Width: " + witdScreen);

        RectTransform rec3 = trans[3].GetComponentInChildren<RectTransform>();
        rec3.anchoredPosition = new Vector2(witdScreen, rec3.anchoredPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
