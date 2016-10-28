using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    

    public int Lifepoints
    {
        get
        {
            return _lifepoints;
        }

        set
        {
            _lifepoints = value;
            if(_lifepoints <= 0)
                EndGame();
        }
    }


    // only for initial lifepoint input via editor
    public int initaialLifes = 3;

    private int _lifepoints;

    // Use this for initialization
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void EndGame()
    {
        //TODO: implement failure state
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
