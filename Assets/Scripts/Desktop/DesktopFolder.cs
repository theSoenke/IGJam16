using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DesktopFolder : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string elementName;


    [Tooltip("time to loose one rage point")]
    public float rageCooldown;

    public Color hoverColor = Color.white;

    public Image smileyImage;


    private Color _normalColor;
    private Image _image;
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
        DesktopItem itemDragged = DesktopItem.itemDragged.GetComponent<DesktopItem>();

        IncreaseRagingStatus(itemDragged.timeFactor);
        itemDragged.Die();


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