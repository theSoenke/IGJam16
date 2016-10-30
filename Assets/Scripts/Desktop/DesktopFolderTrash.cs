using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DesktopFolderTrash : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor = Color.white;

    private Color _normalColor;
    private Image _image;


    void Start()
    {

        _image = GetComponent<Image>();
        _normalColor = _image.color;
    }


    public void OnDrop(PointerEventData eventData)
    {
        DesktopWorkItem itemDragged = DesktopWorkItem.itemDragged.GetComponent<DesktopWorkItem>();

        if (Random.value > 0.5f)
        {
            GameController.Instance.Lifepoints--;
            //TODO: VFX/SFX
        }
        itemDragged.Die();

        GetComponent<AudioSource>().Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (DesktopWorkItem.itemDragged != null)
        {
            _image.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color = _normalColor;
    }
}
