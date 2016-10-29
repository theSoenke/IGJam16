using UnityEngine;

public class DesktopController : MonoBehaviour
{
    public Transform screen;
    public GameObject itemPrefab;
    public int gridSize = 8;
    public int padding = 40;
    public int workOrderAreaWidth = 500;
    public int workOrderAreaHeight = 600;
    public int tileWidth;
    public int tileHeight;

    private int _spawnedItems;
    private DesktopWorkItem[,] _itemGrid;


    void Start()
    {
        tileWidth = (workOrderAreaWidth - padding * 2) / gridSize;
        tileHeight = (workOrderAreaHeight - padding * 2) / gridSize;
        _itemGrid = new DesktopWorkItem[gridSize, gridSize];

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
                Debug.Log(pos);
                pos.x *= tileWidth;
                pos.y *= tileHeight;
                Debug.Log(pos);
                Debug.Log(padding);
                pos += new Vector3(padding, padding, 0);
                Debug.Log("after " + pos);
                GameObject itemObject = (GameObject)Instantiate(itemPrefab);
                itemObject.transform.SetParent(screen);
                itemObject.transform.localPosition = pos;
                _itemGrid[randX, randY] = itemObject.GetComponent<DesktopWorkItem>();
                _spawnedItems++;
                break;
            }
        }
    }
}
