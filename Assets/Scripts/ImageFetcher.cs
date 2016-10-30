// Get the latest webcam shot from outside "Friday's" in Times Square
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFetcher
{
    private ImageReceiver _imageReceiver;
	private int page;
	private bool idle;

    public ImageFetcher(ImageReceiver imageReceiver)
    {
        _imageReceiver = imageReceiver;
		page = 1;
		idle = true;
    }

	public bool Idle() {
		return idle;
	}

    public IEnumerator FetchImage(string title, string path)
    {
        WWW www = new WWW(path);
        yield return www;

        Texture2D tex = new Texture2D(2, 2);
        if (!tex.LoadImage(www.bytes))
        {
            Debug.Log("Failed to download image " + path);
        }

        _imageReceiver.OnNewImage(title, tex);
    }

    public IEnumerator GetGallery()
    {
		idle = false;
        Debug.Log("Starf loading images");

        // string url = MakeAuthReuest ();
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers["Authorization"] = "Client-ID " + "24638144948bc87";

        WWW www = new WWW("https://api.imgur.com/3/gallery/r/adviceanimals/time/" + page, null, headers);
        yield return www;

        var json = JSON.Parse(www.text);
        var data = json["data"];
		Debug.Log (json);

        for (int i = 0; i < data.Count; i++)
        {
            var image = data[i];
            if (!image["animated"].AsBool && !image["is_album"].AsBool)
            {
                yield return FetchImage(image["title"], image["link"]);
            }
        }

		page++;
		idle = true;

        Debug.Log("Done loading images");
    }
}