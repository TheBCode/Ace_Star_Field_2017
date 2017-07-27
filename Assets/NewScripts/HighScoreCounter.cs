using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreCounter : MonoBehaviour
{

    public Text highScoreText;
    public int highScore = 0;
    public int playerScore;

    // Use this for initialization
    void Awake()
    {
        highScore = PlayerPrefs.GetInt("SpaceShmupHighScoreCounter");
        highScoreText.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        Text scoreText = GameObject.Find("PlayerScore").GetComponent<Text>();
        int score = int.Parse(scoreText.text.Substring(7));

        if (score > PlayerPrefs.GetInt("SpaceShmupHighScoreCounter"))
        {
            PlayerPrefs.SetInt("SpaceShmupHighScoreCounter", score);
            highScoreText.text = "High Score: " + score;
            highScore = score;
        }
    }
}
