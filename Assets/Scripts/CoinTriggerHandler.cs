using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTriggerHandler : MonoBehaviour
{
    [SerializeField] private int scoreWorth = 10;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player!!!");
            Destroy(gameObject);
        }
    }
}
