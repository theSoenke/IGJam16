using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class DesktopFolder : MonoBehaviour, IDesktopItem, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("time to loose one rage point")]
    public float rageCooldown;

    public Color hoverColor = Color.white;

    public Image smileyImage;
    public StatusBar statusBar;


    private Color _normalColor;
    private Image _image;
    private Animator _animator;
    private float _nextRageCooldown;
    private float _workDoneTimestamp = 0;

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



    private Image _assignedImage;
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


    private int RageStatusColleague
    {
        get
        {
            return _rageStatusColleague;
        }

        set
        {
            _rageStatusColleague = value;
            SynchronizeSpriteWithRageStatus();
        }
    }




    void Start()
    {
        _animator = GetComponent<Animator>();

        _image = GetComponent<Image>();
        _normalColor = _image.color;

        _nextRageCooldown = Time.time + rageCooldown;



        RageStatusColleague = (int)Smiley.Happy;

        //Zuweisung des Sprites zum Image
        SynchronizeSpriteWithRageStatus();

        _workingStateColleague = false;
    }


    private void Update()
    {
        if (!_workingStateColleague)
        {
            if (Time.time > _nextRageCooldown)
                decreaseRagingStatus();
        }
        else
        {
            _nextRageCooldown = Time.time + rageCooldown;
            if (Time.time > _workDoneTimestamp)
            {
                _workingStateColleague = false;
            }
        }

    }





    private void SynchronizeSpriteWithRageStatus()
    {
        switch (RageStatusColleague)
        {
            case 1:
                smileyImage.overrideSprite = smileyHappy;
                break;
            case 2:
                smileyImage.overrideSprite = smileySmiling;
                break;
            case 3:
                smileyImage.overrideSprite = smileyNeutral;
                break;
            case 4:
                smileyImage.overrideSprite = smileyAngry;
                break;
            case 5:
                smileyImage.overrideSprite = smileyRaging;
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
        if (_workingStateColleague)
            return;


        DesktopWorkItem itemDragged = DesktopWorkItem.itemDragged.GetComponent<DesktopWorkItem>();

        _workingStateColleague = true;
        statusBar.duration = itemDragged.workTimeSec;
        statusBar.gameObject.SetActive(true);
        _workDoneTimestamp = Time.time + itemDragged.workTimeSec;

        IncreaseRagingStatus(itemDragged.timeFactor);
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