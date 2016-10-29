﻿using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Zuweisung an eine Image-Instanz
public class DesktopFolder : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string elementName;

    [Tooltip("time to loose one rage point")]
    public float rageCooldown;

    public Color hoverColor = Color.white;

    private Color normalColor;
    private Image image;
    private Animator _animator;
    private float nextRageCooldown;

    //all the fucking smileys here

    #region  smileys

    public Sprite smileyHappy;
    public Sprite smileySmiling;
    public Sprite smileyNeutral;
    public Sprite smileyAngry;
    public Sprite smileyRaging;

    #endregion


    //Gemütszustand des Kollegen, am Anfang noch Happy
    //je mehr Arbeit er abkriegt, desto wütender wird er
    private int _rageStatusColleague;

    //arbeitet der Kollege gerade an einem Projekt?
    private bool _workingStateColleague;

    private Image _smileyImage;

   

   
    public DesktopController DesktopController { get; set; }


    private int RageStatusColleague
    {
        get
        {
            return _rageStatusColleague;
        }

        set
        {
            SynchronizeSpriteWithRageStatus();
            _rageStatusColleague = value;
        }
    }

   

    private enum Smiley { Happy = 1, Smiling = 2, Neutral = 3, Angry = 4, Raging = 5 };
    private enum ElementType { Folder = 1, Trash = 2, WorkOrder = 3 };


    void Start()
    {
        _smileyImage = GetComponentInChildren<Image>();
        _animator = GetComponent<Animator>();

        image = GetComponent<Image>();
        normalColor = image.color;

        nextRageCooldown = Time.time + rageCooldown;
        


        RageStatusColleague = (int)Smiley.Happy;

        //Zuweisung des Sprites zum Image
        SynchronizeSpriteWithRageStatus();

        _workingStateColleague = false;
    }

    private void Update()
    {
        if (!_workingStateColleague)
        {
            if(Time.time > nextRageCooldown)
                decreaseRagingStatus();
        }
        else
        {
            nextRageCooldown = Time.time + rageCooldown;
        }
    }


    private void SynchronizeSpriteWithRageStatus()
    {
        switch (RageStatusColleague)
        {
            case 1:
                _smileyImage.overrideSprite = smileyHappy;
                break;
            case 2:
                _smileyImage.overrideSprite = smileySmiling;
                break;
            case 3:
                _smileyImage.overrideSprite = smileyNeutral;
                break;
            case 4:
                _smileyImage.overrideSprite = smileyAngry;
                break;
            case 5:
                _smileyImage.overrideSprite = smileyRaging;
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
        RageStatusColleague = RageStatusColleague + timeValue;

        if (RageStatusColleague > 5)
        {
            //decrease life
            RageStatusColleague = (int)Smiley.Happy;
            GameController.Instance.Lifepoints--;
        }
    }

    public void decreaseRagingStatus()
    {

        if ((RageStatusColleague > (int)Smiley.Happy) && (_workingStateColleague == false))
        {
            RageStatusColleague = RageStatusColleague - 1;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        DesktopItem itemDragged = DesktopItem.itemDragged.GetComponent<DesktopItem>();

        IncreaseRagingStatus(itemDragged.lifeTimeSec);
        itemDragged.Die();


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