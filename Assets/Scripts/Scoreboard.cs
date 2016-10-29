using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private float _score = 0;

    private float _lastDisplayUpdate = Time.time;


    public float scorePerSecond = 1;
    public Text scoreDisplay;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        _score += scorePerSecond/Time.deltaTime;
        if (Time.deltaTime - _lastDisplayUpdate > 1)
        {
            _lastDisplayUpdate = Time.time;
            scoreDisplay.text = Mathf.RoundToInt(_score).ToString();
        }
    }
}
