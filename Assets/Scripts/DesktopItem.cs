using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DesktopItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image assignedImage;
    public Sprite assignedSprite;

    public Timer deadLineExpiringTimer;
    public Timer killTimer;
    public int deadLineInMinutes;

    public static GameObject itemDragged;

    private Vector3 startPosition;
    private Transform startParent;
    private int _state;

    private enum StateWorkOrder { New = 1, DeadLineExpiring = 2 };


    void Start()
    {
        assignedImage = GetComponent<Image>();
        assignedImage.overrideSprite = assignedSprite;

        _state = (int)StateWorkOrder.New;

        deadLineExpiringTimer = new Timer(e =>
       {
           ChangeStateToDeadLineExpiring();
       }, null, 0, (int)System.TimeSpan.FromMinutes(deadLineInMinutes).TotalMilliseconds);

    }

    private void ChangeStateToDeadLineExpiring()
    {
        _state = (int)StateWorkOrder.DeadLineExpiring;

        killTimer = new Timer(e =>
        {
            //Destroy(gameObject);
        }, null, 0, (int)System.TimeSpan.FromMinutes(1).TotalMilliseconds);
    }

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