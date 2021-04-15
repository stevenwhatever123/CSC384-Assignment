using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStateManager playerStateManager;

    private bool InPowerUp = false;

    void Start()
    {
        playerStateManager = GameObject.Find("GameManager").GetComponent<PlayerStateManager>();
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
                Destroy(other.gameObject);
            }
        }
    }
}
