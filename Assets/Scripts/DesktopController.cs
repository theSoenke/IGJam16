using UnityEngine;
using System.Collections;

public class DesktopController : MonoBehaviour
{
	public GameObject _screen;

    private DesktopElementInterface[,] _grid = new DesktopElementInterface[8, 8];

	public const int ScreenWidth = 800;
	public const int ScreenHeight = 600;
	public const int GridSize = 8;
	public const float TileWidth = ScreenWidth / GridSize;
	public const float TileHeight = ScreenHeight / GridSize;

    void Start()
    {
		
    }

    void Update()
    {

    }

	public void addDesktopElement(DesktopElementInterface element) {
		element.DesktopController = this;
	}

    DesktopPosition getSnapPosition(Vector2 screenPosition)
    {
		int x = (int) Mathf.Round(screenPosition.x / TileWidth);
		int y = (int) Mathf.Round(screenPosition.y / TileHeight);
		if (_grid [x, y] != null) {
			return null;
		}
		return new DesktopPosition(x, y);
    }

	DesktopPosition getEmptyPosition() 
	{
		for (int y = 0; y < _grid.Length; y++) 
		{
			for (int x = 0; x < _grid.Length; x++) 
			{
				if (_grid [x, y] == null) {
					return new DesktopPosition (x, y);
				}
			}
		}
		return null;
	}
}
