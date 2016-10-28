using UnityEngine;
using System.Collections;

public class DesktopElementFolder : MonoBehaviour,DesktopElementInterface {


	string _elementName;
	int _elementType;
	double _desktopPositionX;
	double _desktopPositionY;


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

	double getDesktopPositionX()
	{
		return this._desktopPositionX;
	}
	void setDesktopPositionX(double posX)
	{
		this._desktopPositionX = posX;
	}

	double getDesktopPositionY()
	{
		return this._desktopPositionY;
	}

	void setDesktopPositionY(double posY)
	{
		this._desktopPositionY = posY;
	}

	void performOnClickAction()
	{
		//do something
	}

}
