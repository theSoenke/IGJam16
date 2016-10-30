using UnityEngine;
using System.Collections;

public class WorkDone : MonoBehaviour
{
    public GameObject workingCanvas;
    public GameObject workItem;

    public void Done()
    {
        workingCanvas.SetActive(false);
        Destroy(workItem);
    }

    
}
