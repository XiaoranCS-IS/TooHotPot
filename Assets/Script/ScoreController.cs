using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController scoreBoard;

    public int score;
    public Text scoreText;

    private void Awake() {
        scoreBoard = this;
    }

    void Start()
    {
        score = 0;
    }

    public void AddScore() {
        score += 50;
        scoreText.text = score.ToString();
    }
}
