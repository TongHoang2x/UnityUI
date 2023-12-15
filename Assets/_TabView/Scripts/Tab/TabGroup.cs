using System.Collections.Generic;
using UnityEngine;
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
public class TabGroup : AppMonoBehaviour
{
    [SerializeField] Color cTabLabelSelected;
    [SerializeField] Color cTabLabelDeSelected;
    [SerializeField] TabButton selectedTabButton;

    [SerializeField] List<TabButton> tabButtons;
    [SerializeField] List<GameObject> tabPages;

    [Space()]
    [Header("LeanTween")]
    [Range(0f, 3f)]
    [SerializeField] float duration = 1f;
    [SerializeField] LeanTweenType leanTweenType = LeanTweenType.easeOutBounce;

    public TabButton GetFirstTabButtons()
    {
        return tabButtons[0];
    }

    public void Subscribe(TabButton _tabButton)
    {
        if (tabButtons == null)
            tabButtons = new List<TabButton>();

        tabButtons.Add(_tabButton);
    }

    private void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTabButton != null && button == selectedTabButton) continue;
            DeActiveTabButton(button);
        }
    }

    public void OnTabEnter(TabButton _tabButton)
    {
        ResetTabs();

        if (selectedTabButton == null || selectedTabButton != _tabButton)
        {
            ActiveTabButton(_tabButton);
        }

    }

    public void OnTabExit(TabButton _tabButton)
    {
        ResetTabs();
    }

    public void OnTabClicked(TabButton _tabButton)
    {
        selectedTabButton = _tabButton;
        ResetTabs();

        ActiveTabButton(_tabButton);

        SwapTabPages(_tabButton.transform.GetSiblingIndex());
    }

    private void ActiveTabButton(TabButton _tabButton)
    {
        LeanTween.value(gameObject, 0f, 1f, duration)
        .setOnUpdate(
            (value) =>
            {
                _tabButton.imgIcon2.fillAmount = value;
            }
        ).setEase(leanTweenType);

        _tabButton.txtLabel.color = cTabLabelSelected;
        //Debug.Log(" " + cTabLabelSelected.r + "_" + cTabLabelSelected.g + " .." + cTabLabelSelected.b);
    }

    private void DeActiveTabButton(TabButton _tabButton)
    {
        _tabButton.imgIcon2.fillAmount = 0;
        _tabButton.txtLabel.color = cTabLabelDeSelected;
    }

    // Swap tabpage when click tabbutton
    private void SwapTabPages(int currentPage)
    {
        for (int i = 0; i < tabPages.Count; i++)
        {
            if (i == currentPage)
            {
                tabPages[i].SetActive(true);
            }
            else
            {
                tabPages[i].SetActive(false);
            }
        }
    }

}
