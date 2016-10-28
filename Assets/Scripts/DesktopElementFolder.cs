using UnityEngine;
using System.Collections;

public class DesktopElementFolder : MonoBehaviour,DesktopElementInterface {


	string _elementName;
	int _elementType;
	double _desktopPositionX;
	double _desktopPositionY;

	int _rageStatusColleague;

	enum Smiley { Happy=1, Smiling=2, Neutral=3, Angry=4, Raging=5};

	public DesktopElementFolder()
	{
	}

	public DesktopElementFolder(string name,int type,double posx, double posy)
	{
		this._elementName = name;
		this._elementType = type;
		this._desktopPositionX = posx;
		this._desktopPositionY = posy;
		this._rageStatusColleague = Smiley.Happy;
	}


	//erhöht den RagingStatus des Kollegen um
	//einen Zeitwert von 1 bis 3
	public void increaseRagingStatus(int timeValue)
	{
		_rageStatusColleague = _rageStatusColleague + timeValue;

		if (_rageStatusColleague > 5) 
		{
			//decrease life
			_rageStatusColleague = Smiley.Happy;
			GameController.Instance.Lifepoints--;
		
		}
	}


	public void decreaseRagingStatus()
	{
		if (_rageStatusColleague > Smiley.Happy) 
		{
			_rageStatusColleague = _rageStatusColleague - 1;
		}
	}




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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

	public double getDesktopPositionX()
	{
		return this._desktopPositionX;
	}

	public void setDesktopPositionX(double posX)
	{
		this._desktopPositionX = posX;
	}


	public double getDesktopPositionY()
	{
		return this._desktopPositionY;
	}

	public void setDesktopPositionY(double posY)
	{
		this._desktopPositionY = posY;
	}

	public void performOnClickAction()
	{
		//do something
	}

}
