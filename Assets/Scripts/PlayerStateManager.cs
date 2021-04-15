using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public float powerUpTime = 8f;
    
    private PlayerState playerState = PlayerState.NORMAL;

    private PlayerController playerController;
    
    private float timer;

    private void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
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
            Debug.Log("Power Up");
        }
    }
}
