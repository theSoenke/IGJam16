using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SomeComponent : MonoBehaviour, ImageReceiver {

	private ImageFetcher _imageFetcher;
	private Texture2D texture = null;

	private Queue<string> _titles;
	private Queue<Texture2D> _images;

	// Use this for initialization
	void Start () {
		Debug.Log("Initializing SomeComponent");
		_titles = new Queue<string>();
		_images = new Queue<Texture2D>();
		_imageFetcher = new ImageFetcher (this);
		StartCoroutine (_imageFetcher.GetGallery());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		if (texture != null) {
			GUILayout.Label (texture);
		}
	}

	public void OnNewImage(string title, Texture2D new_texture)
	{
		_titles.Enqueue (title);
		_images.Enqueue (new_texture);

		texture = new_texture;
	}
}
