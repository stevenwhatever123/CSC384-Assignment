using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinTriggerHandler : MonoBehaviour
{
    [SerializeField] private int scoreWorth = 10;

    public ScoreManager scoreManager;

    void Awake()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.addScore(scoreWorth);
            Destroy(gameObject);
        }
    }
}
