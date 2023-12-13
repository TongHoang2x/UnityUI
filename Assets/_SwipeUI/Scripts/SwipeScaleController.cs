using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeScaleController : MonoBehaviour, IEndDragHandler
{
    [SerializeField] int maxPage;
    int currentPage;
    Vector3 targetPos;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPagesRect;
    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;
    float dragThreshould;   // bien drag man hinh

    [SerializeField] Image[] barImage;
    [SerializeField] Sprite barClosed, barOpen;
    //[SerializeField] Color barColosed, barOpen;
    
    [SerializeField] Button nextBtn, previousBtn;

    [SerializeField] RectTransform[] rectPages;
    [SerializeField] LeanTweenType tweenTyperectPages;

    private void Awake()
    {
        currentPage = 1;
        targetPos = levelPagesRect.localPosition;

        dragThreshould = Screen.width / 15;

        UpdateBar();

        UpdateArrowButton();

        UpdateLevelPage();
    }

    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos -= pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        levelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);        
        UpdateBar();
        UpdateArrowButton();
        UpdateLevelPage();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if(Mathf.Abs( drag end postion - drag start postion > dragthreshould ))
        if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > dragThreshould)
        {
            if (eventData.position.x > eventData.pressPosition.x) Previous();
            else Next();
        }
        else
        {
            MovePage();
        }
    }

    void UpdateLevelPage(){
        foreach(var item in rectPages){
            item.LeanScaleY(1f, 0.1f).setEase(tweenTyperectPages);
        }
        rectPages[currentPage -1].LeanScaleY(1.3f, 0.1f).setEase(tweenTyperectPages);;
    }

    void UpdateBar()
    {
        foreach (var item in barImage)
        {
            item.sprite = barClosed;
            //item.color = barColosed;
        }
        barImage[currentPage - 1].sprite = barOpen;
        //barImage[currentPage -1].color = barOpen;
    }

    void UpdateArrowButton(){
        nextBtn.interactable = true;
        previousBtn.interactable = true;
        if(currentPage == 1) previousBtn.interactable = false;
        else if( currentPage == maxPage) nextBtn.interactable = false;
    }
}
