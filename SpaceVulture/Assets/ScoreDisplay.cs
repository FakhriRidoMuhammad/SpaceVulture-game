using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = ("Final Score: " + ScoreKeeper.score);
    }

    public void ResetScore()
    {
        ScoreKeeper.Reset();
    }
}
