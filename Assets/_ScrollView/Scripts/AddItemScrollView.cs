using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemScrollView : MonoBehaviour
{
    [SerializeField] GameObject prefabItem;
    [SerializeField] RectTransform contenRect;
    [SerializeField] int itemCount = 1;

    private void Start()
    {
        //Debug.Log("Height:" + contenRect.sizeDelta.y);
        //Debug.Log("Height item: " + prefabItem.GetComponent<RectTransform>().sizeDelta.y);
        
        // chieu cao cua 1 item
        float prefabItemHeight = prefabItem.GetComponent<RectTransform>().sizeDelta.y;

        // chieu cao tong cac item
        prefabItemHeight *= itemCount;
        // chieu caco cac item + spacing + padding top
        prefabItemHeight = prefabItemHeight + (itemCount - 1) * 10 + 50;

        // chieu cao rectransfrom cua content trong scrollview
        Vector2 contentSizeDelta = new Vector2(0, prefabItemHeight);
        contenRect.sizeDelta = contentSizeDelta;


        for (int i = 0; i < itemCount; i++)
        {
            GameObject obj = Instantiate(prefabItem, contenRect);

        }

    }


}
