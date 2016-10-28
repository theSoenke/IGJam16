using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DesktopElementWorkOrder : MonoBehaviour {

	public Image _assignedImage;
	public Sprite _assignedSprite;

	// Use this for initialization
	void Start () 
	{
		_assignedImage = GetComponent<Image> ();
		_assignedImage.overrideSprite = _assignedSprite;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
