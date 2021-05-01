using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    private EnemyState aiState = EnemyState.FINDPATH;
    private Rigidbody2D rb;
    private AgentMovementManager agentMovementManager;
    private GameObject spawnPoint;
    private PlayerStateManager playerStateManager;
    private SpriteRenderer spriteRenderer;
    private GameObject[] allGhost;
    public Collider2D colliderToDisable;

    private Vector3 ghostSpawnPoint;
    
    private Vector3 target;

    public AStarGrid grid;
    
    private List<AStarNode> path;

    public AStarPathfinding pathfinding;

    public GameObject player;

    public float scatterTime = 7;

    public float chaseTime = 20;

    public float movementSpeed;

    public int scoreWorth;

    public int timeToSpawn;

    private float timer;

    private float spawnTimer = 0;

    private int sizeX;
    private int sizeY;
    private AStarNode destination;

    public bool flee = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        agentMovementManager = GameObject.Find("GameManager").GetComponent<AgentMovementManager>();
        spawnPoint = GameObject.Find("SpawnPoint");
        playerStateManager = GameObject.Find("GameManager").GetComponent<PlayerStateManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        path = new List<AStarNode>();
        path.Add(new AStarNode(true, transform.position, 0, 0));
        ghostSpawnPoint = transform.position;
        allGhost = GameObject.FindGameObjectsWithTag("Ghost");
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= timeToSpawn)
        {
            timer += Time.deltaTime;
            if ((timer >= scatterTime && aiState != EnemyState.SEEKPLAYER) && agentMovementManager.IsAllowedToMove())
            {
                aiState = EnemyState.SEEKPLAYER;
                timer = 0;
            }
            Tick();
        }
    }

    void Tick()
    {
        if (!playerStateManager.IsDead())
        {
            switch (aiState)
            {
                case EnemyState.FINDPATH:
                    if (agentMovementManager.IsAllowedToMove())
                    {
                        FindPathState();  
                    }
                    break;
                case EnemyState.WANDER:
                    if (agentMovementManager.IsAllowedToMove())
                    {
                        WanderState();
                    }
                    break;
                case EnemyState.SEEKPLAYER:
                    if (agentMovementManager.IsAllowedToMove())
                    {
                        SeekPlayerState();
                    }
                    break;
                case EnemyState.FLEEFROMPLAYER:
                    if (agentMovementManager.IsAllowedToMove())
                    {
                        FleeFromPlayerState();
                    }
                    break;
                case EnemyState.FLEEFROMPLAYERWANDER:
                    if (agentMovementManager.IsAllowedToMove())
                    {
                        FleeFromPlayerWanderState();
                    }
                    break;
                case EnemyState.RETURNTOBASE:
                    ReturnToBaseState();
                    break;
            }
        }
    }

    public void PlayerPowerUp()
    {
        aiState = EnemyState.FLEEFROMPLAYER;
        timer = 0;
        spriteRenderer.color = new Color(1, 0, 0, 1);
        flee = true;
    }

    public void PlayerBackToNormal()
    {
        aiState = EnemyState.FINDPATH;
        timer = 0;
        spriteRenderer.color = new Color(1, 1, 1, 1);
        flee = false;
    }

    void FindPathState()
    {
        sizeX = grid.GetGrid().GetUpperBound(0); // Get size of X
        sizeY = grid.GetGrid().GetUpperBound(1); // Get size of Y

        destination = grid.GetGrid()[0, 0];
        do
        {
            int x = Random.Range(0, sizeX);
            int y = Random.Range(0, sizeY);
            destination = grid.GetGrid()[x, y];
        } while (!destination.walkable);
                
        target = destination.worldPosition;
        aiState = EnemyState.WANDER;
    }

    void WanderState()
    {
        if (Vector2.Distance(transform.position, target) <= 1)
        {
            aiState = EnemyState.FINDPATH;
        }
        else
        {
            UpdatePath(target);
            FollowPath(movementSpeed);
        }
    }

    void SeekPlayerState()
    {
        target = player.transform.position;
        
        if (timer >= chaseTime && chaseTime != 0)
        {
            aiState = EnemyState.FINDPATH;
            timer = 0;
        }

        if (Vector2.Distance(transform.position, target) <= 1)
        {
            timer = 0;
            Debug.Log("GG");
        }
        else
        {
            UpdatePath(target);
            FollowPath(movementSpeed);
        }
    }

    void FleeFromPlayerState()
    {
        sizeX = grid.GetGrid().GetUpperBound(0); // Get size of X
        sizeY = grid.GetGrid().GetUpperBound(1); // Get size of Y

        destination = grid.GetGrid()[0, 0];
        bool farFromPlayer = false;
        do
        {
            int x = Random.Range(0, sizeX);
            int y = Random.Range(0, sizeY);
            destination = grid.GetGrid()[x, y];
            farFromPlayer = Vector3.Distance(transform.position, 
                destination.worldPosition) >= 10;
        } while (!destination.walkable && farFromPlayer);
                
        target = destination.worldPosition;
        aiState = EnemyState.FLEEFROMPLAYERWANDER;
    }

    void FleeFromPlayerWanderState()
    {
        //spriteRenderer.color = new Color(1, 0, 0, 1);
        if (timer >= chaseTime)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
            aiState = EnemyState.FINDPATH;
            timer = 0;
        }

        if (Vector2.Distance(transform.position, target) <= 1)
        {
            aiState = EnemyState.FLEEFROMPLAYER;
        }
        else
        {
            UpdatePath(target);
            FollowPath(movementSpeed);
        }
    }

    void ReturnToBaseState()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
        if (!agentMovementManager.IsAllowedToMove())
        {
            if (timeToSpawn > 0)
            {
                target = ghostSpawnPoint;
            }
            else
            {
                target = spawnPoint.transform.position;
            }
            colliderToDisable.enabled = false;

            if (Vector2.Distance(transform.position, target) <= 1)
            {
                colliderToDisable.enabled = true;
                foreach (GameObject friend in allGhost)
                {
                    friend.GetComponent<Collider2D>().enabled = true;
                }
                aiState = EnemyState.FINDPATH;
                agentMovementManager.setAllowToMove(true);
            }
            else
            {
                foreach (GameObject friend in allGhost)
                {
                    friend.GetComponent<Collider2D>().enabled = false;
                }
                
                UpdatePath(target);
                FollowPath(movementSpeed * 3);
            }
            
        }
    }

    public void Eaten()
    {
        aiState = EnemyState.RETURNTOBASE;
        flee = false;
    }

    public void FriendEaten()
    {
        spawnTimer = 0;
    }

    public bool isFleeing()
    {
        return flee;
    }
    
    void FollowPath(float movementSpeed)
    {
        Vector3 tempTargetPosition =
            new Vector3(path[0].worldPosition.x, path[0].worldPosition.y, 
                transform.position.z);
        
        //Vector3 direction = (path[0].worldPosition - transform.position).normalized;
        Vector3 direction = (tempTargetPosition - 
                             transform.position).normalized;
        
        //Debug.Log("Direction: " + direction);

        Vector3 newPosition = transform.position + direction * movementSpeed;
        rb.MovePosition(newPosition);
    }

    void UpdatePath(Vector3 target)
    {
        pathfinding.FindPath(transform.position, target);
        path = pathfinding.GetPath();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && (!playerStateManager.IsPowerUp() || !flee))
        {
            Debug.Log("GG");
            playerStateManager.Dead();
            
            foreach (GameObject friend in allGhost)
            {
                if (friend.GetInstanceID() == this.GetInstanceID())
                {
                    continue;
                }
                friend.GetComponent<EnemyScript>().FriendEaten();
            }
        }

        if (other.gameObject.CompareTag("Ghost") && aiState != EnemyState.RETURNTOBASE)
        {
            aiState = EnemyState.FINDPATH;
        }
    }

    public int getScore()
    {
        return scoreWorth;
    }

    public Vector3 getGhostSpawnPoint()
    {
        return ghostSpawnPoint;
    }

    public void SetStateToFindPath()
    {
        aiState = EnemyState.FINDPATH;
    }
}
