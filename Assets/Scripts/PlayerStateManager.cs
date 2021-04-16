using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public float powerUpTime = 8f;
    
    private PlayerState playerState = PlayerState.NORMAL;

    private PlayerController playerController;

    public GameObject[] allGhosts;

    private float timer;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        allGhosts = GameObject.FindGameObjectsWithTag("Ghost");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == PlayerState.POWERUP)
        {
            timer += Time.deltaTime;
            if (timer >= powerUpTime)
            {
                playerState = PlayerState.NORMAL;
                playerController.setInPowerUp(false);
                
                foreach (GameObject enemy in allGhosts)
                {
                    if (enemy != null)
                    {
                        enemy.GetComponent<EnemyScript>().PlayerPowerUp();
                    }
                }
                
                timer = 0;
                Debug.Log("End");
            }
        }
    }

    public void PickUpEnergizer()
    {
        if (playerState != PlayerState.POWERUP)
        {
            playerState = PlayerState.POWERUP;
            playerController.setInPowerUp(true);
            
            foreach (GameObject enemy in allGhosts)
            {
                if (enemy != null)
                {
                    enemy.GetComponent<EnemyScript>().PlayerPowerUp();
                }
            }

            Debug.Log("Power Up");
        }
    }
}
