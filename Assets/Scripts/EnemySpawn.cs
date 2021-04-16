using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float secondsToSpawn;

    public EnemyScript enemyController;

    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= secondsToSpawn)
        {
            enemyController.enabled = true;
            this.enabled = false; 
        }
    }
}
