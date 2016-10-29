﻿// Get the latest webcam shot from outside "Friday's" in Times Square
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SimpleJSON;
using System.IO;

public class ImageFetcher {

	/*private string _redditUrl = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
	private string _clientId = "UqZAQ0ngVptioA";
	private string _state = "make random string"; // TODO
	private string _redirectUrl = "http%3A%2F%2F127.0.0.2";
	private string _authorizeUrl = "http://www.reddit.com/api/v1/authorize";
	// https://?client_id=&response_type=code&state=123penis123&redirect_uri=
	private string _oauthToken;

	public string MakeAuthReuest() {
		string url = _authorizeUrl;
		url += "?client_id=" + _clientId;
		url += "&response_type=code";
		url += "&state=" + _state;
		url += "&redirect_url=" + _redirectUrl;
		url += "&scope=read";
		return url;
	}*/

	private ImageReceiver _imageReceiver;

	public ImageFetcher(ImageReceiver imageReceiver) {
		_imageReceiver = imageReceiver;
	}

	public IEnumerator FetchImage(string title, string path)
	{
		WWW www = new WWW(path);
		yield return www;

		Texture2D tex = new Texture2D(2, 2);
		if (!tex.LoadImage (www.bytes)) {
			Debug.Log ("Failed to download image " + path);
		}

		File.WriteAllBytes(title + ".png", www.bytes);

		_imageReceiver.OnNewImage (title, tex);
	}

	public IEnumerator GetGallery() {
		Debug.Log ("Starf loading images");

		// string url = MakeAuthReuest ();
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers["Authorization"] = "Client-ID " + "24638144948bc87"; 

		WWW www = new WWW("https://api.imgur.com/3/gallery/r/funny", null, headers);
		yield return www;

		Debug.Log ("preparse");
		var json = JSON.Parse(www.text);
		Debug.Log ("postparse");
		var data = json ["data"];

		for (int i = 0; i < data.Count; i++) {
			var image = data [i];
			if (!image ["animated"].AsBool) {
				yield return FetchImage (image ["title"], image ["link"]);
			}
		}

		Debug.Log ("Done loading images");
	}
}