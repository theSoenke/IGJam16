using UnityEngine;
using System.Collections;

public class DesktopController : MonoBehaviour {

	private DesktopElementInterface[,] _grid = new DesktopElementInterface[8, 8];

	void Start () {
			
	}

	void Update () {
	
	}

	DesktopPosition getSnapPosition(Vector2 screenPosition) {
		return new DesktopPosition (1, 1);	
	}
}
