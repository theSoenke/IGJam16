using UnityEngine;
using System.Collections;

public class DesktopPosition {

	public int _x;
	public int _y;

	public DesktopPosition(int x, int y) {
		_x = x;
		_y = y;
	}

	public Vector2 toScreenPosition() {
		return new Vector2 (_x * DesktopController.TileWidth, _y * DesktopController.TileHeight);
	}
}

