using UnityEngine;
using UnityEngine.UI;

public class EmailController : MonoBehaviour
{
    public Text mailText;


    public void SetMailText(string content)
    {
        mailText.text = content;
    }
}
