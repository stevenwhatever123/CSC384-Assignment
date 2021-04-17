using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryBlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
