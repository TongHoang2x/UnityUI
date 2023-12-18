using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
public class TabButton : AppMonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public int id;
    public GetChild iconChild;
    public Image imgIcon1, imgIcon2;

    public TextMeshProUGUI txtLabel;

    // reference to TabGroup
    public TabGroup tabGroup;

    /// <summary>
    /// Override tu AppMonoBehaviour de khi nhan reset no se load het cac component
    /// </summary>
    protected override void Load_Components()
    {
        tabGroup = GetComponentInParent<TabGroup>();
        iconChild = GetComponentInChildren<GetChild>();

        imgIcon1 = iconChild.img1;
        imgIcon2 = iconChild.img2;

        txtLabel = GetComponentInChildren<TextMeshProUGUI>();
        tabGroup.Subscribe(this);
    }

    /// <summary>
    /// Khi click chon tabbutton
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabClicked(this);
    }

    /// <summary>
    /// Khi di chuot len tren tabbutton
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    /// <summary>
    /// Khi chuot k con tren tabbutton
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

}
