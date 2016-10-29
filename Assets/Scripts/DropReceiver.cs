using UnityEngine;
using UnityEngine.EventSystems;

public class DropReceiver : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject itemDragged = DragHandler.itemDragged;
        itemDragged.transform.SetParent(transform);
        Destroy(itemDragged);
    }
}
