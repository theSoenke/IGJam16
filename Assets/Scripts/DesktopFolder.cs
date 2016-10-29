﻿using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Zuweisung an eine Image-Instanz
public class DesktopFolder : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string elementName;
    public int elementType;
    public Color hoverColor = Color.white;

    private Color normalColor;
    private Image image;

    //Gemütszustand des Kollegen, am Anfang noch Happy
    //je mehr Arbeit er abkriegt, desto wütender wird er
    private int _rageStatusColleague;

    //arbeitet der Kollege gerade an einem Projekt?
    private bool _workingStateColleague;

    private DesktopPosition _desktopPosition;
    private Image _assignedImage;
    private Image _smileyImage;

    //Dieser Timer aktualisiert den rageStatus des Kollegen
    private Timer timer;

    public DesktopPosition DesktopPosition
    {
        get
        {
            return _desktopPosition;
        }
        set
        {
            _desktopPosition = value;
            UpdateRectTransform();
        }
    }
    public DesktopController DesktopController { get; set; }

    public Vector2 FolderScreenPosition { get; set; }

    private enum Smiley { Happy = 1, Smiling = 2, Neutral = 3, Angry = 4, Raging = 5 };
    private enum ElementType { Folder = 1, Trash = 2, WorkOrder = 3 };


    void Start()
    {
        _assignedImage = GetComponent<Image>();
        _smileyImage = GetComponentInChildren<Image>();

        image = GetComponent<Image>();
        normalColor = image.color;

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

    private void UpdateRectTransform()
    {
        GetComponent<RectTransform>().position = _desktopPosition.toScreenPosition();
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
            image.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = normalColor;
    }
}