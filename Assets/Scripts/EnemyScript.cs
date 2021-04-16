using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    private EnemyState aiState = EnemyState.FINDPATH;
    private Rigidbody2D rb;
    private Vector3 target;

    public AStarGrid grid;
    
    private List<AStarNode> path;

    public AStarPathfinding pathfinding;

    public GameObject player;

    public float scatterTime = 7;

    public float chaseTime = 20;

    public float movementSpeed;

    private float timer;

    private int sizeX;
    private int sizeY;
    private AStarNode destination;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        path = new List<AStarNode>();
        path.Add(new AStarNode(true, transform.position, 0, 0));
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= scatterTime && aiState != EnemyState.SEEKPLAYER)
        {
            aiState = EnemyState.SEEKPLAYER;
            timer = 0;
        }
        Tick();
    }

    void Tick()
    {
        switch (aiState)
        {
            case EnemyState.FINDPATH:
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
                break;
            case EnemyState.WANDER:
                if (Vector2.Distance(transform.position, target) <= 1)
                {
                    aiState = EnemyState.FINDPATH;
                }
                else
                {
                    UpdatePath(target);
                    FollowPath();
                }
                break;
            case EnemyState.SEEKPLAYER:
                target = player.transform.position;

                if (timer >= chaseTime)
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
                    FollowPath();
                }
                break;
            case EnemyState.FLEEFROMPLAYER:
                sizeX = grid.GetGrid().GetUpperBound(0); // Get size of X
                sizeY = grid.GetGrid().GetUpperBound(1); // Get size of Y

                destination = grid.GetGrid()[0, 0];
                do
                {
                    int x = Random.Range(0, sizeX);
                    int y = Random.Range(0, sizeY);
                    destination = grid.GetGrid()[x, y];
                    bool farFromPlayer = Vector3.Distance(transform.position, 
                        destination.worldPosition) <= 10;
                } while (!destination.walkable);
                
                target = destination.worldPosition;
                aiState = EnemyState.FLEEFROMPLAYERWANDER;
                break;
            case EnemyState.FLEEFROMPLAYERWANDER:
                
                if (timer >= chaseTime)
                {
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
                    FollowPath();
                }
                break;
        }
    }

    public void PlayerPowerUp()
    {
        aiState = EnemyState.FLEEFROMPLAYER;
    }

    public void PlayerBackToNormal()
    {
        aiState = EnemyState.FINDPATH;
    }
    
    void FollowPath()
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
}
