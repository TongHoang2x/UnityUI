using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/*
    TabView
        TabPages(Image, LayoutElement[Preferred width, preferred height], HorizontalLayoutGroup)
            Page 0(VerticalLayoutGroup[control child size tick width, height])
            Page 1(VerticalLayoutGroup[control child size tick width, height])
            Page ...
        TabGroup(TabGroup.cs, LayoutElement, HorizontalLayoutGroup)
            Tab 0( VerticalLayoutGroup, LayoutElement, TabButton.cs)
            Tab 1( VerticalLayoutGroup, LayoutElement, TabButton.cs)
            Tab ...
        
*/
public class TabGroup : AppMonoBehaviour, IEndDragHandler
{
    [SerializeField] Color cTabLabelSelected;
    [SerializeField] Color cTabLabelDeSelected;
    [SerializeField] TabButton selectedTabButton;
    [SerializeField] int current = -1;

    [SerializeField] List<TabButton> tabButtons;
    [SerializeField] List<GameObject> tabPages;

    [Space()]
    [Header("LeanTween TabPage")]
    [Range(0f, 3f)]
    [SerializeField] float timeTabButton = 0.3f;
    [SerializeField] LeanTweenType leanTweenType = LeanTweenType.linear;


    [Space()]
    [Header("LeanTween Pages")]
    [SerializeField] Vector3 posStart;
    [SerializeField] Vector3 posEnd;
    [SerializeField][Range(0.1f, 2f)] float timePage = 0.5f;
    [SerializeField] LeanTweenType leanTweenTypePage = LeanTweenType.linear;

    public TabButton GetFirstTabButtons()
    {
        return tabButtons[0];
    }

    /// <summary>
    /// TabButton co tham chieu den tabgroup, de goi den TabGroup de tu dang ky vao
    /// </summary>
    /// <param name="_tabButton"></param>
    public void Subscribe(TabButton _tabButton)
    {
        if (tabButtons == null)
            tabButtons = new List<TabButton>();

        tabButtons.Add(_tabButton);
    }

    /// <summary>
    /// Duyet mang tabbuttons dua ve deactive
    /// </summary>
    private void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTabButton != null && button == selectedTabButton) continue;
            DeActiveTabButton(button);
        }
    }

    /// <summary>
    /// Khi di chuot len tabbutton
    /// </summary>
    /// <param name="_tabButton"></param>
    public void OnTabEnter(TabButton _tabButton)
    {
        ResetTabs();

        if (selectedTabButton == null || selectedTabButton != _tabButton)
        {
            ActiveTabButton(_tabButton);
        }
    }

    /// <summary>
    /// Khi chuot khong tren tabbuton
    /// </summary>
    /// <param name="_tabButton"></param>
    public void OnTabExit(TabButton _tabButton)
    {
        ResetTabs();
    }

    /// <summary>
    /// Khi click vao tabbutton
    /// Chon tab. Neu tabbutton da dc chon thi khong lam lenh fia sau
    /// Gan current = tabbutton 
    /// Goi reset va cac hieu ung 
    /// </summary>
    /// <param name="_tabButton"></param>
    public void OnTabClicked(TabButton _tabButton)
    {
        selectedTabButton = _tabButton;
        if (current == selectedTabButton.id) return;
        current = selectedTabButton.id;

        ResetTabs();

        ActiveTabButton(_tabButton);

        ActiveTabPages(_tabButton.transform.GetSiblingIndex());
    }

    /// <summary>
    /// Active tabbuton va goi hieu ung bang leantween
    /// </summary>
    /// <param name="_tabButton"></param>
    private void ActiveTabButton(TabButton _tabButton)
    {
        AnimTabButton(_tabButton);
    }

    /// <summary>
    /// Deactive tabbutton goi hieu ung
    /// </summary>
    /// <param name="_tabButton"></param>
    private void DeActiveTabButton(TabButton _tabButton)
    {
        _tabButton.imgIcon2.fillAmount = 0;
        _tabButton.txtLabel.color = cTabLabelDeSelected;
    }

    /// <summary>
    /// Goi active tabpage
    /// </summary>
    /// <param name="currentPage"></param>
    private void ActiveTabPages(int currentPage)
    {
        for (int i = 0; i < tabPages.Count; i++)
        {
            if (i == currentPage)
            {
                tabPages[i].SetActive(true);

                // goi hieu ung 
                AnimPage(tabPages[i].GetComponent<RectTransform>());
                // dao chieu hieu ung
                if (currentPage == 0) { posStart.x = -posStart.x; }
                if (currentPage == tabPages.Count - 1) { posStart.x = posStart.x * -1; }

            }
            else
            {
                tabPages[i].SetActive(false);
            }

        }
    }

    /// <summary>
    /// Hieu ung tabbutton
    /// </summary>
    /// <param name="_tabButton"></param>
    private void AnimTabButton(TabButton _tabButton)
    {
        LeanTween.value(gameObject, 0f, 1f, timeTabButton)
                .setOnUpdate(
                    (value) =>
                    {
                        _tabButton.imgIcon2.fillAmount = value;
                    }
                ).setEase(leanTweenType);

        _tabButton.txtLabel.color = cTabLabelSelected;
    }

    /// <summary>
    /// hieu ung anim cho tabpage
    /// </summary>
    /// <param name="rectPage"></param>
    private void AnimPage(RectTransform rectPage)
    {
        rectPage.localPosition = posStart;
        rectPage.LeanMoveLocal(posEnd, timePage).setEase(leanTweenTypePage).setDelay(0.1f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        if (Mathf.Abs(eventData.position.y - eventData.pressPosition.y) > 15)
        {
            if (eventData.position.y > eventData.pressPosition.y)
                Debug.Log("Len");
            else
                Debug.Log("xuong");
        }
        else
        {
            Debug.Log("ok");
        }
    }
}
