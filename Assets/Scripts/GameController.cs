﻿using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DesktopController), typeof(Scoreboard))]
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public EmailController EmailController { get; private set; }


    public GameObject mainCanvas;
    public GameObject gameOverCanvas;


    private DesktopController _desktopController;
    private Scoreboard _scoreboard;

    public int Lifepoints
    {
        get
        {
            return _lifepoints;
        }

        set
        {
            _lifepoints = value;
            if (_lifepoints <= 0)
                EndGame();
        }
    }

    public DesktopController DesktopController
    {
        get
        {
            return _desktopController;
        }

        set
        {
            _desktopController = value;
        }
    }

    public float ScoreMultiplier
    {
        get
        {
            return _scoreboard.scoreFactor;
        }
        set
        {
            _scoreboard.scoreFactor = value;
        }
    }

    // only for initial lifepoint input via editor
    public int initialLifes = 3;

	public AnimationCurve Difficulty;

    private int _lifepoints;

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

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
        _desktopController = GetComponent<DesktopController>();
        EmailController = GetComponent<EmailController>();
        _scoreboard = GetComponent<Scoreboard>();
    }

    private void EndGame()
    {
        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }


    void Start()
    {

    }

	void Update() 
	{

	}
}
