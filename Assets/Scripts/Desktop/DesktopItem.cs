using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DesktopItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemDragged;

    public Image assignedImage;
    public Sprite assignedSprite;

    private int _deadLineInMinutes;
    private Timer _killTimer;
    private Timer _deadLineExpiringTimer;
    private Vector3 _startPosition;
    private Transform _startParent;
    private int _state;

    private enum StateWorkOrder
    {
        New,
        DeadLineExpiring
    };


    void Start()
    {
        assignedImage = GetComponent<Image>();
        assignedImage.overrideSprite = assignedSprite;

        _state = (int)StateWorkOrder.New;

        _deadLineExpiringTimer = new Timer(e =>
       {
           ChangeStateToDeadLineExpiring();
       }, null, 0, (int)System.TimeSpan.FromMinutes(_deadLineInMinutes).TotalMilliseconds);

    }

    private void ChangeStateToDeadLineExpiring()
    {
        _state = (int)StateWorkOrder.DeadLineExpiring;

        _killTimer = new Timer(e =>
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
        _startPosition = transform.position;
        _startParent = transform.parent;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemDragged = null;
        if (transform.parent == _startParent)
        {
            transform.position = _startPosition;
        }
    }
}