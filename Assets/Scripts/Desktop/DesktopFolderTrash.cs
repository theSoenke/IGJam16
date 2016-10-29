using UnityEngine;
using UnityEngine.UI;

public class DesktopFolderTrash : DesktopFolder
{
    public Image assignedImage;
    public Sprite assignedSprite;

    private enum ElementType { Folder = 1, Trash = 2, WorkOrder = 3 };


    void Start()
    {
        assignedImage = GetComponent<Image>();
        assignedImage.overrideSprite = assignedSprite;

    }

    public string getElementName()
    {
        return elementName;
    }
    public void setElementName(string name)
    {
        elementName = name;
    }
}
