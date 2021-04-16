using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStateManager playerStateManager;

    private AgentMovementManager agentMovementManager;

    private EnemyScript enemyController;
    
    private GameObject spawnPoint;

    private bool InPowerUp = false;

    void Start()
    {
        playerStateManager = GameObject.Find("GameManager").GetComponent<PlayerStateManager>();
        agentMovementManager = GameObject.Find("GameManager").GetComponent<AgentMovementManager>();
        spawnPoint = GameObject.Find("SpawnPoint");
    }

    public void setInPowerUp(bool b)
    {
        InPowerUp = b;
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
                    enemyController.Eaten();
                }

                agentMovementManager.setAllowToMove(false);

                //Destroy(other.gameObject);
            }
        }
    }
}
