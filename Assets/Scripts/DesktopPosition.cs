using UnityEngine;
using System.Collections;

public class DesktopPosition {

	public int _x;
	public int _y;

	private const int _gridSlots = 8;
	private const int _slotWidth = 800 / _gridSlots;
	private const int _slotHeight = 600 / _gridSlots;

	public DesktopPosition(int x, int y) {
		_x = x;
		_y = y;
	}

	public Vector2 toScreenPosition() {
		return new Vector2 ();
	}
}

