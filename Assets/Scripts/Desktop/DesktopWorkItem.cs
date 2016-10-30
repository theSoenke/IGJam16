using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class DesktopWorkItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource dropSound;
    public float lifeTimeSec;
    public float workTimeSec;
    public Vector2 GridPosition { get; set; }

    //dumb stuff: determinds the rage induced on the coworker dropped on
    [Range(1, 3)]
    public int timeFactor = 1;

    public List<GameObject> clocks;

    public static GameObject itemDragged;

    private Vector3 _startPosition;
    private Transform _startParent;
    private float _deadLine;

    private Animator _animator;

    private bool _warning = false;
    private bool _dead = false;
    public bool _beingWorkedOn = false;

    private const string DeathAnim = "DestroyItem";
    private const string WarningAnim = "Flashing";

    void Start()
    {
        if (timeFactor > 3)
            timeFactor = 3;
        _deadLine = Time.time + lifeTimeSec;
        _animator = GetComponent<Animator>();
        _animator.Play("Empty");
    }

    private void Update()
    {

        if (Time.time > _deadLine && !_dead && !_beingWorkedOn)
        {
            _dead = true;
            GameController.Instance.Lifepoints--;
            Die();
        }

        if ((_deadLine - Time.time) < (lifeTimeSec / 3) && !_warning && !_beingWorkedOn)
        {
            _warning = true;
            _animator.Play(WarningAnim);
        }
    }

    public void Die()
    {
        if (GameController.Instance == null)
        {
            return;
        }

        GameController.Instance.DesktopController.RemoveItem(this);
        Destroy(gameObject, 0.5f);
        _startPosition = transform.position;
        _animator.Play(DeathAnim);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!DesktopController.isMenuOpen)
        {
            transform.position = eventData.position;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemDragged = gameObject;
        _startPosition = transform.position;
        _startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        itemDragged = null;
        if (transform.parent == _startParent)
        {
            transform.position = _startPosition;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameController.Instance.ShowWorkingMenu(workTimeSec, gameObject);
        _beingWorkedOn = true;
        GameController.Instance.Working = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < timeFactor; i++)
        {
            clocks[i].SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach(var c in clocks)
            c.SetActive(false);
    }
}