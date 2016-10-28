using UnityEngine;
using System.Collections;

public class DesktopController : MonoBehaviour
{

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

    DesktopPosition getSnapPosition(Vector2 screenPosition)
    {
		float x = screenPosition.x / TileWidth;
		float y = screenPosition.y / TileHeight;
		return new DesktopPosition((int)Mathf.Round(x), (int)Mathf.Round(y));
    }
}
