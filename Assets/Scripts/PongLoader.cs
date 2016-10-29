using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PongLoader : MonoBehaviour {

	public void LoadPong() {
		SceneManager.LoadScene ("Pong", LoadSceneMode.Additive);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
