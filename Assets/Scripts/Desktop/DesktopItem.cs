using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DesktopItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{


    public int lifeTimeSec;

    public static GameObject itemDragged;

    private Vector3 _startPosition;
    private Transform _startParent;
    private float _deadLine;

    private Animator _animator;

    private const string DEATH_ANIM = "";




    void Start()
    {
        _deadLine = Time.time + lifeTimeSec;
        _animator = GetComponent<Animator>();



    }

    private void Update()
    {

        if (Time.time > _deadLine)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject, 0.5f);
        _animator.Play(DEATH_ANIM);
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