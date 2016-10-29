using UnityEngine;
using UnityEngine.EventSystems;

public class DropReceiver : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on drop");
    }
}
