using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailController : MonoBehaviour
{
    public Text mailText;
    public GameObject emailView;
    public List<TextAsset> emails;


    public void ShowMessage(string content)
    {
        emailView.SetActive(true);
        mailText.text = content;
    }

    public void ShowRandomSpam()
    {
        int rand = Random.Range(0, emails.Count);
        ShowMessage(emails[rand].text);
    }
}
