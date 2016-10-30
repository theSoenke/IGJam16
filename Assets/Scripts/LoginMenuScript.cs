using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginMenuScript : MonoBehaviour {

	public InputField _inputFieldUserName;
	string _userName;

	public void ChangeScene(string sceneName)
	{
		_userName = _inputFieldUserName.text.ToString();
		PlayerPrefs.SetString ("SavedPlayerName", _userName);
		Debug.Log (PlayerPrefs.GetString("SavedPlayerName"));
		Application.LoadLevel (sceneName);
	}

	public void Shutdown()
	{
		Debug.Log ("Shutdown");
		Application.Quit ();
	}
}
