using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemDragged;
    private Vector3 startPosition;
    private Transform startParent;


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemDragged = null;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
    }
}
