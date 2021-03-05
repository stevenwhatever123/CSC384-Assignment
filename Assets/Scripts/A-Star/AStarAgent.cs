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
        Vector3 direction = (path[0].worldPosition - transform.position).normalized;
        
        /*
        Vector3 newPosition = new Vector3(transform.position.x + direction.x * ( 1 + speed),
            transform.position.y + direction.y * ( 1 + speed),
            transform.position.z + direction.z * ( 1 + speed));
            */
        
        
        //Vector3 newPosition = transform.position + direction * speed;
        //rb.MovePosition(newPosition);
        Vector3 newPosition = new Vector3(path[0].worldPosition.x, path[0].worldPosition.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed);

        //rb.MovePosition(path[0].worldPosition);
    }
}
