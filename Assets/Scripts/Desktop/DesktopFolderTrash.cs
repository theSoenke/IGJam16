using UnityEngine;
using UnityEngine.UI;

public class DesktopFolderTrash : MonoBehaviour, IDesktopItem
{
    public Image assignedImage;
    public Sprite assignedSprite;

    private enum ElementType
    {
        WorkItem,
        Folder,
        Trash
    };


    void Start()
    {
        assignedImage = GetComponent<Image>();
        assignedImage.overrideSprite = assignedSprite;
    }
}
