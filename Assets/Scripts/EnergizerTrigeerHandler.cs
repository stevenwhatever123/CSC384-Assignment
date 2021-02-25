using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergizerTrigeerHandler : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player!!!");
            Destroy(gameObject);
        }
    }
}
