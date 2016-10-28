using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DesktopElementTrash : MonoBehaviour,DesktopElementInterface {

	public Image _assignedImage;
	public Sprite _assignedSprite;

	public string _elementName;
	public int _elementType;

	public DesktopPosition DesktopPosition { get; set; }
	public DesktopController DesktopController { get; set; }

	enum ElementType { Folder=1, Trash=2, WorkOrder=3 };

	// Use this for initialization
	void Start () 
	{
		_assignedImage = GetComponent<Image> ();
		_assignedImage.overrideSprite = _assignedSprite;
	
		this._elementType = (int)ElementType.Trash;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
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
