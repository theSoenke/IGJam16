using UnityEngine;
using UnityEngine.UI;

public class ImageScroller : MonoBehaviour
{
    public GameObject imageElementPrefab;
    public Transform content;
    public Texture2D texture;

    private ScrollRect scrollRect;


    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        scrollRect.onValueChanged.AddListener(OnScrollValueChanged);

        for (int i = 0; i < 5; i++)
        {
            AddImage();
        }
    }

    void Update()
    {

    }

    private void OnScrollValueChanged(Vector2 call)
    {

    }

    public void AddImage()
    {
        GameObject imageGo = (GameObject)Instantiate(imageElementPrefab, transform.position, Quaternion.identity);
        imageGo.transform.SetParent(content);
        Image image = imageGo.GetComponent<Image>();
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        image.sprite = sprite;
    }
}