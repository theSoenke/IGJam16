using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DesktopController), typeof(Scoreboard))]
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public EmailController EmailController { get; private set; }


    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public GameObject pongCanvas;
    public GameObject redditCanvas;
    public GameObject workingCanvas;
    public int minSpamTime = 5;
    public int maxSpamTime = 30;



    private DesktopController _desktopController;
    private Scoreboard _scoreboard;

    private float _multiplierTimer;
    private float _nextSpamEmailTimer;

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

    public bool Working
    {
        get
        {
            return _scoreboard.working;
        }

        set
        {
            _scoreboard.working = value;
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
        _nextSpamEmailTimer = Random.Range(minSpamTime, maxSpamTime);
    }

    private void EndGame()
    {
        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }


    void Start()
    {
        _lifepoints = initialLifes;
    }

    void Update()
    {
        _multiplierTimer += Time.deltaTime;
        if (_multiplierTimer > 5)
        {
            _multiplierTimer = 0;
            UpdateMultiplier();
        }

        _nextSpamEmailTimer -= Time.deltaTime;
        if (_nextSpamEmailTimer <= 0)
        {
            this.EmailController.ShowRandomSpam();
            _nextSpamEmailTimer = Random.Range(minSpamTime, maxSpamTime);
        }
    }

    void UpdateMultiplier()
    {
        if (pongCanvas.activeSelf || redditCanvas.activeSelf)
        {
            ScoreMultiplier += 2;
        }
    }

    public void ShowWorkingMenu(float duration, GameObject sender)
    {
        workingCanvas.SetActive(true);
        StatusBar sb = workingCanvas.GetComponentInChildren<StatusBar>();
        var wd = workingCanvas.GetComponentInChildren<WorkDone>();
        wd.workItem = sender;
        sb.duration = duration;
    }
}
