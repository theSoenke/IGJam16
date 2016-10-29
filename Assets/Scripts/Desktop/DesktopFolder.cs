using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Zuweisung an eine Image-Instanz
public class DesktopFolder : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string elementName;
    public int elementType;
    public Color hoverColor = Color.white;
    public List<Sprite> smilies;

    private Color _normalColor;
    private Image _image;

    //Gemütszustand des Kollegen, am Anfang noch Happy
    //je mehr Arbeit er abkriegt, desto wütender wird er
    private int _rageStatusColleague;

    //arbeitet der Kollege gerade an einem Projekt?
    private bool _workingStateColleague;

    private Image _assignedImage;
    private Image _smileyImage;
    private Timer timer;

    private enum Smiley
    {
        Happy,
        Smiling,
        Neutral,
        Angry,
        Raging
    };

    private enum ElementType
    {
        Item,
        Folder,
        Trash
    };


    void Start()
    {
        _assignedImage = GetComponent<Image>();
        _smileyImage = GetComponentInChildren<Image>();

        _image = GetComponent<Image>();
        _normalColor = _image.color;

        timer = new Timer((e) =>
        {
            decreaseRagingStatus();
        }, null, 0, (int)System.TimeSpan.FromMinutes(1).TotalMilliseconds);


        _rageStatusColleague = (int)Smiley.Happy;

        //Zuweisung des Sprites zum Image
        SynchronizeSpriteWithRageStatus();

        elementType = (int)ElementType.Folder;
        _workingStateColleague = false;
    }

    void Update()
    {
        SynchronizeSpriteWithRageStatus();
    }

    private void SynchronizeSpriteWithRageStatus()
    {
        switch (_rageStatusColleague)
        {
            case 1:
                _smileyImage.overrideSprite = Resources.Load<Sprite>("Images/smiley_happy");
                break;
            case 2:
                _smileyImage.overrideSprite = Resources.Load<Sprite>("Images/smiley_smiling");
                break;
            case 3:
                _smileyImage.overrideSprite = Resources.Load<Sprite>("Images/smiley_neutral");
                break;
            case 4:
                _smileyImage.overrideSprite = Resources.Load<Sprite>("Images/smiley_angry");
                break;
            case 5:
                _smileyImage.overrideSprite = Resources.Load<Sprite>("Images/smiley_raging");
                break;
        }
    }

    public void ChangeWorkingState()
    {
        _workingStateColleague = !_workingStateColleague;
    }

    //erhöht den RagingStatus des Kollegen um
    //einen Zeitwert von 1 bis 3
    public void IncreaseRagingStatus(int timeValue)
    {
        _rageStatusColleague = _rageStatusColleague + timeValue;

        if (_rageStatusColleague > 5)
        {
            //decrease life
            _rageStatusColleague = (int)Smiley.Happy;
            GameController.Instance.Lifepoints--;
        }
    }

    public void decreaseRagingStatus()
    {

        if ((_rageStatusColleague > (int)Smiley.Happy) && (_workingStateColleague == false))
        {
            _rageStatusColleague = _rageStatusColleague - 1;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject itemDragged = DesktopItem.itemDragged;
        itemDragged.transform.SetParent(transform);
        Destroy(itemDragged);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (DesktopItem.itemDragged != null)
        {
            _image.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color = _normalColor;
    }
}