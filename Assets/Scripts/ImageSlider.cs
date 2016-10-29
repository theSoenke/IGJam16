using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSlider : MonoBehaviour, ImageReceiver
{
    public Image currentSliderImage;
    public Button nextImageButton;
    public int timeout = 5;

    private float timer = 0;
    private Texture2D texture;
    private Queue<Texture2D> imageList;


    void Start()
    {
        imageList = new Queue<Texture2D>();
        nextImageButton.onClick.AddListener(NextImage);
        //texture = new Texture2D(100, 100);

        ImageFetcher imageFetcher = new ImageFetcher(this);
        StartCoroutine(imageFetcher.GetGallery());
    }

    void Update()
    {
        if (timer <= 0)
        {
            nextImageButton.interactable = true;
        }
        else
        {
            nextImageButton.interactable = false;
            timer -= Time.deltaTime;
        }
    }

    public void NextImage()
    {
        if (timer <= 0)
        {
            if (imageList.Count != 0)
            {
                texture = imageList.Dequeue();
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                currentSliderImage.sprite = sprite;
                timer = timeout;
            }
        }
    }

    public void OnNewImage(string title, Texture2D newTexture)
    {
        if (texture == null)
        {
            texture = newTexture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            currentSliderImage.sprite = sprite;
        }
        else
        {
            imageList.Enqueue(texture);
        }
    }
}