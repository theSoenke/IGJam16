using UnityEngine;
using System.Collections;

public class DesktopElementFolder : MonoBehaviour,DesktopElementInterface {


	string _elementName;
	int _elementType;
	double _desktopPositionX;
	double _desktopPositionY;

	enum Smiliy { Happy, Smiling, Neutral, Angry};

	public DesktopElementFolder()
	{
	}

	public DesktopElementFolder(string name,int type,double posx, double posy)
	{
		this._elementName = name;
		this._elementType = type;
		this._desktopPositionX = posx;
		this._desktopPositionY = posy;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	string getElementName()
	{
		return this._elementName;
	}
	void setElementName(string name)
	{
		this._elementName = name;
	}


	int getElementType()
	{
		return this._elementType;
		
	}

	void setElementType(int type)
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
