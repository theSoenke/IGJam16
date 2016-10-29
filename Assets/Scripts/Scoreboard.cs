using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private float _score = 0;

    private float _lastDisplayUpdate;


    public float scorePerSecond = 1;
    public float scoreFactor = 1;
    public float refreshTick = 1;
    public Text scoreDisplay;

    void Start()
    {
        _lastDisplayUpdate = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        _score += scorePerSecond * Time.deltaTime * scoreFactor;
        if (Time.time - _lastDisplayUpdate > refreshTick)
        {
            _lastDisplayUpdate = Time.time;
            scoreDisplay.text = Mathf.RoundToInt(_score).ToString();
        }
    }
}
