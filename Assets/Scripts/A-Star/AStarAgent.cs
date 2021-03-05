using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarAgent : MonoBehaviour
{
    public Transform target;
    public float speed = 1.2f;
    private List<AStarNode> path;

    public AStarPathfinding pathfinding;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        path[0] = new AStarNode(true, transform.position, 0, 0);
    }

    void Update()
    {
        pathfinding.FindPath(transform.position, target.position);
        path = pathfinding.GetPath();
        FollowPath();
    }

    void FollowPath()
    {
        Vector3 tempTargetPosition =
            new Vector3(path[0].worldPosition.x, path[0].worldPosition.y, transform.position.z);
        
        //Vector3 direction = (path[0].worldPosition - transform.position).normalized;
        Vector3 direction = (tempTargetPosition - transform.position).normalized;
        
        //Debug.Log("Direction: " + direction);

        Vector3 newPosition = transform.position + direction * speed;
        rb.MovePosition(newPosition);
    }
}
