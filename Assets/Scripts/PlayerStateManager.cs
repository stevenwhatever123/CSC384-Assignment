using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public float powerUpTime = 8f;
    
    private PlayerState playerState = PlayerState.NORMAL;

    private PlayerController playerController;

    private AgentMovementManager agentMovementManager;

    private LifeManager lifeManager;

    private GameObject playerObject;

    public GameObject[] allGhosts;

    public GameObject gameOverText;
    
    public static int numberOfLifes = 0;

    [SerializeField] public int numberOfLifesHelper = 3;

    public int deadTime = 2;

    private float timer;

    private bool playDead = false;

    private float deadTimer;

    private float spawnTimer;

    private void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        agentMovementManager = GameObject.Find("GameManager").GetComponent<AgentMovementManager>();
        lifeManager = GameObject.Find("GameManager").GetComponent<LifeManager>();
        playerObject = GameObject.Find("Player");
        allGhosts = GameObject.FindGameObjectsWithTag("Ghost");

        if (numberOfLifes == 0)
        {
            numberOfLifes = numberOfLifesHelper;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == PlayerState.POWERUP && agentMovementManager.IsAllowedToMove())
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
                        enemy.GetComponent<EnemyScript>().PlayerBackToNormal();
                    }
                }
                
                timer = 0;
                Debug.Log("End");
            }
        } else if (playDead)
        {
            DeadAnimation();
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

    public bool IsPowerUp()
    {
        return playerState == PlayerState.POWERUP;
    }

    public void Dead()
    {
        numberOfLifes--;
        lifeManager.setLife(numberOfLifes);
        playerState = PlayerState.DEAD;
        agentMovementManager.setAllowToMove(false);
        if (numberOfLifes < 1)
        {
            gameOverText.SetActive(true);
        }
        else
        {
            playDead = true;
            deadTimer = 0;
        }
    }

    public void DeadAnimation()
    {
        deadTimer += Time.deltaTime;
        if (deadTimer >= deadTime)
        {
            playerState = PlayerState.NORMAL;
            playerObject.transform.position = playerController.getPlayerSpawnPoint();
            foreach (GameObject enemy in allGhosts)
            {
                enemy.transform.position = enemy.GetComponent<EnemyScript>().getGhostSpawnPoint();
                enemy.GetComponent<EnemyScript>().SetStateToFindPath();
            }
            agentMovementManager.setAllowToMove(true);
            playDead = false;
        }
    }

    public bool IsDead()
    {
        return playerState == PlayerState.DEAD;
    }

    public int GetNumberOfLife()
    {
        return numberOfLifes;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, playerController.gameObject.transform.position);
    }

    public void LoadPlayer()
    {
        //PlayerInformation data = SaveSystem.LoadPlayer();
    }
}
