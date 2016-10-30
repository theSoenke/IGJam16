using UnityEngine;
using System.Collections;

public class WorkDone : MonoBehaviour
{
    public GameObject workingCanvas;
    public GameObject workItem;

    public void Done()
    {
        workingCanvas.SetActive(false);
        workItem.GetComponent<DesktopWorkItem>().Die();
        GameController.Instance.Working = false;
    }

    
}
