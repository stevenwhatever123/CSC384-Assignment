using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaTriggerHandler : MonoBehaviour
{
    [SerializeField] private int scoreWorth = 10;

    public ShockWave Shock;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.addScore(scoreWorth);
            Shock.setWaveActive(true);
            Destroy(gameObject);
        }
    }
}
