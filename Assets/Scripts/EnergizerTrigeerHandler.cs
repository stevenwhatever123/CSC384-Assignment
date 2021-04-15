using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergizerTrigeerHandler : MonoBehaviour
{
    [SerializeField] private int scoreWorth = 50;

    public ScoreManager scoreManager;
    public PlayerStateManager playerStateManager;

    void Awake()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        playerStateManager = GameObject.Find("GameManager").GetComponent<PlayerStateManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scoreManager.addScore(scoreWorth);
            playerStateManager.PickUpEnergizer();
            Destroy(gameObject);
        }
    }
}
