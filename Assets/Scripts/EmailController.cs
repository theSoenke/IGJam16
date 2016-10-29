using UnityEngine;
using UnityEngine.UI;

public class EmailController : MonoBehaviour
{
    public Text mailText;
    public GameObject emailView;


    public void SetMailText(string content)
    {
        emailView.SetActive(true);
        mailText.text = content;
    }
}
