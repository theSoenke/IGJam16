using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;


public class DesktopElementWorkOrder : MonoBehaviour {

	public Image _assignedImage;
	public Sprite _assignedSprite;

	public Timer deadLineExpiringTimer;
	public Timer killTimer;
	public int deadLineInMinutes;

	enum StateWorkOrder { New=1, DeadLineExpiring=2};

	int _state;





	// Use this for initialization
	void Start () 
	{
		_assignedImage = GetComponent<Image> ();
		_assignedImage.overrideSprite = _assignedSprite;

		_state = (int)StateWorkOrder.New;

		deadLineExpiringTimer = new Timer (e => 
		{
				changeStateToDeadLineExpiring();
		}, null, 0,(int) System.TimeSpan.FromMinutes (deadLineInMinutes).TotalMilliseconds);
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void changeStateToDeadLineExpiring()
	{
		_state = (int)StateWorkOrder.DeadLineExpiring;

		killTimer = new Timer (e => {
			Destroy(gameObject);
		}, null,0, (int)System.TimeSpan.FromMinutes (1).TotalMilliseconds);

		
	}

	public void WaitAndDestroy()
	{
		
	}

}
