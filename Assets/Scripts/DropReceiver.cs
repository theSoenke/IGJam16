using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropReceiver : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor = Color.white;

    private Color normalColor;
    private Image image;


    void Start()
    {
        image = GetComponent<Image>();
        normalColor = image.color;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject itemDragged = DragHandler.itemDragged;
        itemDragged.transform.SetParent(transform);
        Destroy(itemDragged);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (DragHandler.itemDragged != null)
        {
            image.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = normalColor;
    }
}
