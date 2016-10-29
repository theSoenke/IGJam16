using UnityEngine;
using UnityEngine.UI;

public class DesktopFolderTrash : MonoBehaviour
{
    public Image assignedImage;
    public Sprite assignedSprite;


    void Start()
    {
        assignedImage = GetComponent<Image>();
        assignedImage.overrideSprite = assignedSprite;
    }
}
