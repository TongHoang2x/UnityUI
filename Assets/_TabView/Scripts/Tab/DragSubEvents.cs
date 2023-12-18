using UnityEngine;

public class DragSubEvents : MonoBehaviour
{
    [SerializeField] int IdSub;
    [SerializeField] RectTransform panelTitle;
    [SerializeField] Vector2 posShow;

    private void Awake()
    {
        // luu lai gia tri ban dau
        panelTitle = GetComponent<RectTransform>();
        posShow = panelTitle.anchoredPosition;
    }

    private void Start()
    {
        DragEvents.MyDragEvents.EventOnDragDown += OnDragDownScreen;
        DragEvents.MyDragEvents.EventOnDragUp += OnDragUpScreen;
    }

    private void OnDestroy()
    {
        DragEvents.MyDragEvents.EventOnDragDown -= OnDragDownScreen;
        DragEvents.MyDragEvents.EventOnDragUp -= OnDragUpScreen;
    }

    private void OnDragDownScreen(int IdSub)
    {
        if (this.IdSub != IdSub) return;

        Debug.Log("Dragdown");
        //panelTitle.anchoredPosition = posShow;
        LeanTween.value(gameObject, panelTitle.anchoredPosition, posShow, 0.3f)
            .setOnUpdate((Vector2 anchoredPos) =>
            {
                // Update the anchoredPosition during the tween
                panelTitle.anchoredPosition = anchoredPos;
            });

    }

    private void OnDragUpScreen(int IdSub)
    {
        if (this.IdSub != IdSub) return;
        
        Debug.Log("OnDragUpScreen" + panelTitle.sizeDelta.y);
        //panelTitle.anchoredPosition = -posShow;
        LeanTween.value(gameObject, panelTitle.anchoredPosition, -posShow, 0.3f)
            .setOnUpdate((Vector2 anchoredPos) =>
            {
                // Update the anchoredPosition during the tween
                panelTitle.anchoredPosition = anchoredPos;
            });

    }

}
