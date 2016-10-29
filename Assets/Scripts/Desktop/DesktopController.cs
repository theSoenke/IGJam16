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
	private float spawnTimer = 0;

    private int _spawnedItems;
    private DesktopWorkItem[,] _itemGrid;


    void Start()
    {
        tileWidth = (workOrderAreaWidth - padding * 2) / gridSize;
        tileHeight = (workOrderAreaHeight - padding * 2) / gridSize;
        _itemGrid = new DesktopWorkItem[gridSize, gridSize];
    }

	public void Update()
	{
		float difficulty = GameController.Instance.Difficulty.Evaluate (Time.time / 60);
		spawnTimer += Time.deltaTime;
		if (spawnTimer > 10) {
			spawnTimer = 0f;
			SpawnItem(difficulty);
		}
			
	}

	private void SpawnItem(float difficulty)
    {
		int itemsToSpawn = (int) Mathf.Ceil(difficulty*10);
		Debug.Log ("Spawning " + itemsToSpawn + " items");

		for (int i = 0; i < difficulty; i++) {
			int randX = Random.Range(0, gridSize - 1);
        	int randY = Random.Range(0, gridSize - 1);

			if (_itemGrid [randX, randY] == null) {
				var pos = new Vector3 (randX, randY, 0);
				pos.x *= tileWidth;
				pos.y *= tileHeight;
				pos += new Vector3 (padding, padding, 0);

				GameObject itemObject = (GameObject)Instantiate (itemPrefab);
				itemObject.transform.SetParent (screen);
				itemObject.transform.localPosition = pos;

				_itemGrid [randX, randY] = itemObject.GetComponent<DesktopWorkItem> ();
			}
		}
    }
}
