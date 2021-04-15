using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreToDisplay;
    
    private int score = 0;
    
    void Start()
    {
        scoreToDisplay = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        
        //scoreToDisplay.text = getScore().ToString();
    }

    void Update()
    {
        scoreToDisplay.text = getScore().ToString();
    }

    public void addScore(int value)
    {
        score += value;
    }

    public int getScore()
    {
        return score;
    }
}
