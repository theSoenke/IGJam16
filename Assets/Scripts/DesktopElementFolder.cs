using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

// Zuweisung an eine Image-Instanz
public class DesktopElementFolder : MonoBehaviour, DesktopElementInterface, IDropHandler {

	public string _elementName;
	public int _elementType;

	public DesktopPosition DesktopPosition { get; set; }
	public DesktopController DesktopController { get; set; }

	int _rageStatusColleague;

	enum Smiley { Happy=1, Smiling=2, Neutral=3, Angry=4, Raging=5};
	enum ElementType { Folder=1, Trash=2, WorkOrder=3 };


	// Use this for initialization
	void Start () 
	{
		this._rageStatusColleague = (int) Smiley.Happy;	
		this._elementType = (int) ElementType.Folder;
	}

	// Update is called once per frame
	void Update () 
	{

	}

	public Vector2 getScreenPosition() {
		return DesktopPosition.toScreenPosition ();
	}

	//erhöht den RagingStatus des Kollegen um
	//einen Zeitwert von 1 bis 3
	public void increaseRagingStatus(int timeValue)
	{
		_rageStatusColleague = _rageStatusColleague + timeValue;

		if (_rageStatusColleague > 5) 
		{
			//decrease life
			_rageStatusColleague = (int) Smiley.Happy;
			GameController.Instance.Lifepoints--;
		
		}
	}


	public void decreaseRagingStatus()
	{
		
		if (_rageStatusColleague > (int) Smiley.Happy) 
		{
			_rageStatusColleague = _rageStatusColleague - 1;
		}
	}

	public void OnDrop(PointerEventData data) {

	}


	public string getElementName()
	{
		return this._elementName;
	}
	public void setElementName(string name)
	{
		this._elementName = name;
	}


	public int getElementType()
	{
		return this._elementType;
		
	}

	public void setElementType(int type)
	{
		this._elementType = type;
	}



	public void performOnClickAction()
	{
		//do something
	}

}
