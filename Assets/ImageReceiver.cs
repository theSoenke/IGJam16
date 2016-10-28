using System;
using UnityEngine;

// Interface for components which await images
public interface ImageReceiver
{
	void OnNewImage (string title, Texture2D texture) ;
}


