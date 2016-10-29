using UnityEngine;
using System.Collections;

public class LoginMenuScript : MonoBehaviour {

	public void ChangeScene(string sceneName)
	{
		Application.LoadLevel (sceneName);
	}
}
