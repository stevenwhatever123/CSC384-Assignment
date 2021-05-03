using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;

    private AgentMovementManager agentMovementManager;

    public float moveDirectionX = -1f;
    public float moveDirectionY = 0f;

    public float movementSpeed = 2f;

    public bool inReplay;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        agentMovementManager = GameObject.Find("GameManager").GetComponent<AgentMovementManager>();
    }

    void Update()
    {
        if (!inReplay)
        {
            if (agentMovementManager.IsAllowedToMove())
            {
                Move();
            }
        }
    }

    public void Move()
    {
        Vector3 newPosition = new Vector3(transform.position.x + moveDirectionX * movementSpeed, 
            transform.position.y + moveDirectionY * movementSpeed, 
            transform.position.z + 0);
        rb.MovePosition(newPosition);
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!inReplay)
        {
            if (agentMovementManager.IsAllowedToMove())
            {
                Vector2 inputValue = context.ReadValue<Vector2>();

                if (inputValue.x != 0 || inputValue.y != 0)
                {
                    moveDirectionX = inputValue.x;
                    moveDirectionY = inputValue.y;
            
                    if (inputValue.x < 0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if(inputValue.x > 0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                    }

                    if (inputValue.y < 0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                    } else if (inputValue.y > 0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 270);
                    }
                }
            }
        }
    }
}
