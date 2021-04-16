using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStateManager playerStateManager;

    private AgentMovementManager agentMovementManager;

    private ScoreManager scoreManager;

    private EnemyScript enemyController;
    
    private GameObject spawnPoint;

    private bool InPowerUp = false;

    private int killCounter = 1;

    void Start()
    {
        playerStateManager = GameObject.Find("GameManager").GetComponent<PlayerStateManager>();
        agentMovementManager = GameObject.Find("GameManager").GetComponent<AgentMovementManager>();
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        spawnPoint = GameObject.Find("SpawnPoint");
    }

    public void setInPowerUp(bool b)
    {
        InPowerUp = b;
        killCounter = 1;
    }

    public bool IsInPowerUp()
    {
        return InPowerUp;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (InPowerUp)
        {
            if (other.gameObject.CompareTag("Ghost"))
            {
                //other.gameObject.transform.position = spawnPoint.transform.position;
                enemyController = other.gameObject.GetComponent<EnemyScript>();
                if (enemyController.isFleeing())
                {
                    scoreManager.addScore(other.gameObject.GetComponent<EnemyScript>().scoreWorth * killCounter);
                    killCounter++;
                    enemyController.Eaten();
                }

                agentMovementManager.setAllowToMove(false);

                //Destroy(other.gameObject);
            }
        }
    }
}
