using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetChild : MonoBehaviour
{
    public Image img1, img2;
    Image[] imgs;

    private void Awake() {
        imgs = GetComponentsInChildren<Image>();
        if(imgs.Length > 0){
            img1 = imgs[0];
            img2 = imgs[1];
        }
    }
}
