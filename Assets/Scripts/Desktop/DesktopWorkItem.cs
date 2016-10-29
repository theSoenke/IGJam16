using UnityEngine;
using UnityEngine.EventSystems;


public class DesktopWorkItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public AudioSource dropSound;
    public float lifeTimeSec;
    public float workTimeSec;

    //dumb stuff: determinds the rage induced on the coworker dropped on
    [Range(1, 3)]
    public int timeFactor = 1;

    public static GameObject itemDragged;

    private Vector3 _startPosition;
    private Transform _startParent;
    private float _deadLine;

    private Animator _animator;

    private bool _warning = false;

    private const string DeathAnim = "DestroyItem";
    private const string WarningAnim = "Flashing";

    void Start()
    {
        _deadLine = Time.time + lifeTimeSec;
        _animator = GetComponent<Animator>();

    }

    private void Update()
    {

        if (Time.time > _deadLine)
        {
            GameController.Instance.Lifepoints--;
            Die();
        }

        if ((_deadLine - Time.time) < (_deadLine / 3) && !_warning)
        {
            _warning = true;
            _animator.Play(WarningAnim);
        }

    }

    public void Die()
    {
        Destroy(gameObject, 0.5f);
        _startPosition = transform.position;
        _animator.Play(DeathAnim);   //TODO: fix anim
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
}