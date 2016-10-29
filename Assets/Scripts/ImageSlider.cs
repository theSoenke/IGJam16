using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSlider : MonoBehaviour, ImageReceiver
{
    public Image currentSliderImage;
    public Button nextImageButton;
    public int timeout = 5;

    private float _timer;
    private Queue<Sprite> _imageQueue;


    void Start()
    {
        _imageQueue = new Queue<Sprite>();
        nextImageButton.onClick.AddListener(NextImage);

        var imageFetcher = new ImageFetcher(this);
        StartCoroutine(imageFetcher.GetGallery());
    }

    void Update()
    {
        if (_timer <= 0)
        {
            nextImageButton.interactable = true;
        }
        else
        {
            nextImageButton.interactable = false;
            _timer -= Time.deltaTime;
        }
    }

    private void NextImage()
    {
        if (_timer <= 0)
        {
            if (_imageQueue.Count == 0) return;
            Sprite sprite = _imageQueue.Dequeue();
            currentSliderImage.sprite = sprite;
            _timer = timeout;
        }
    }

    public void OnNewImage(string title, Texture2D newTexture)
    {
        var sprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f));

        if (currentSliderImage.sprite == null)
        {
            currentSliderImage.sprite = sprite;
        }
        else
        {
            _imageQueue.Enqueue(sprite);
        }
    }
}