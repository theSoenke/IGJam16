using UnityEngine;
using UnityEngine.UI;

public class ImageSlider : MonoBehaviour
{
    public Image currentSliderImage;
    public Button nextImageButton;
    public int timeout = 5;

    private float timer = 0;
    private Texture2D texture;
    private Sprite sprite;


    void Start()
    {
        nextImageButton.onClick.AddListener(NextImage);
        texture = new Texture2D(100, 100);
        sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
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
            currentSliderImage.sprite = sprite;
            timer = timeout;
        }
    }
}