using UnityEngine;
using System.Collections;
using System.Security.Policy;

public class StatusBar : MonoBehaviour
{
    public RectTransform Fg;
    
    public float duration;

    private float unitsPerSecond;
    // Use this for initialization
    void Start()
    {
        unitsPerSecond = 0.2618529f / duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(Fg.localScale.x > 0.01)
        Fg.localScale = new Vector3(Fg.localScale.x - unitsPerSecond * Time.deltaTime, Fg.localScale.y, Fg.localScale.z);
    }
}
