using UnityEngine;

public class DesktopController : MonoBehaviour
{
    public Transform screen;
    public GameObject itemPrefab;

    public const int ScreenWidth = 800;
    public const int ScreenHeight = 600;
    public const int GridSize = 8;
    public const float TileWidth = ScreenWidth / GridSize;
    public const float TileHeight = ScreenHeight / GridSize;

    private int spawnedItems;
    private DesktopItem[,] _itemGrid;


    void Start()
    {
        _itemGrid = new DesktopItem[GridSize, GridSize];

        for (int i = 0; i < 8; i++)
        {
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        int maxItems = GridSize * GridSize;

        if (spawnedItems >= maxItems)
        {
            return;
        }

        while (true)
        {
            int randX = Random.Range(0, GridSize - 1);
            int randY = Random.Range(0, GridSize - 1);

            if (_itemGrid[randX, randY] == null)
            {
                var pos = new Vector3(randX * 20, randY * 20, 0);
                pos += screen.position;
                GameObject itemObject = (GameObject)Instantiate(itemPrefab, pos, Quaternion.identity);
                itemObject.transform.SetParent(screen);
                _itemGrid[randX, randY] = itemObject.GetComponent<DesktopItem>();
                spawnedItems++;
                break;
            }
        }
    }
}
