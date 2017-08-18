using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public Text scoreText;
    public static int score;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void Score(int points)
    {
        score += points;
        scoreText.text = ("Score: " + score);
    }

    public static void Reset()
    {
        score = 0;
    }
}
