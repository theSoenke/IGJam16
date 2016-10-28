using UnityEngine;
using System.Collections;

// Zuweisung an eine Image-Instanz
public class DesktopElementFolder : MonoBehaviour,DesktopElementInterface {


	public string _elementName;
	public int _elementType;

	public DesktopPosition FolderDesktopPosition { get; set;}

	public Vector2 FolderScreenPosition { get; set; }


	//Gemütszustand des Kollegen, am Anfang noch Happy
	//je mehr Arbeit er abkriegt, desto wütender wird er
	int _rageStatusColleague;

	//arbeitet der Kollege gerade an einem Projekt?
	bool _workingStateColleague;


	enum Smiley { Happy=1, Smiling=2, Neutral=3, Angry=4, Raging=5};
	enum ElementType { Folder=1, Trash=2, WorkOrder=3 };


	// Use this for initialization
	void Start () 
	{
		this._rageStatusColleague = (int) Smiley.Happy;	
		this._elementType = (int) ElementType.Folder;
		this._workingStateColleague = false;
	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void ChangeWorkingState()
	{
		this._workingStateColleague = !this._workingStateColleague;
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
