using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreToDisplay;
    
    private static int score = 0;
    
    private static int scoreBeforePlaying = 0;

    void Start()
    {
        scoreToDisplay = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        scoreBeforePlaying = score;
        //scoreToDisplay.text = getScore().ToString();
    }

    void Update()
    {
        scoreToDisplay.text = getScore().ToString();
    }

    public static void addScore(int value)
    {
        score += value;
    }

    public static int getScore()
    {
        return score;
    }

    public static int getScoreBeforePlay()
    {
        return scoreBeforePlaying;
    }

    public static void setScore(int value)
    {
        score = value;
    }
}
