using UnityEngine;

public class DesktopController : MonoBehaviour
{
    public Transform screen;
    public GameObject itemPrefab;
    public int gridSize = 8;
    public int spacing = 20;

    private int _spawnedItems;
    private DesktopItem[,] _itemGrid;


    void Start()
    {
        _itemGrid = new DesktopItem[gridSize, gridSize];

        for (int i = 0; i < 8; i++)
        {
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        int maxItems = gridSize * gridSize;

        if (_spawnedItems >= maxItems)
        {
            return;
        }

        while (true)
        {
            int randX = Random.Range(0, gridSize - 1);
            int randY = Random.Range(0, gridSize - 1);

            if (_itemGrid[randX, randY] == null)
            {
                var pos = new Vector3(randX, randY, 0);
                pos *= spacing;
                pos += screen.position;
                GameObject itemObject = (GameObject)Instantiate(itemPrefab, pos, Quaternion.identity);
                itemObject.transform.SetParent(screen);
                _itemGrid[randX, randY] = itemObject.GetComponent<DesktopItem>();
                _spawnedItems++;
                break;
            }
        }
    }
}
