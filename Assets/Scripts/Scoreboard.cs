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
    public Text scoreDisplay;

    void Update()
    {
        _score += scorePerSecond * Time.deltaTime * scoreFactor;
		string text = "" + GameController.Instance.Lifepoints + " lives | " + scoreFactor + "x | " + Mathf.Floor(_score);
		scoreDisplay.text = text;
    }
}
