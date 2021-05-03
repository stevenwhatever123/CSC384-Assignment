using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReplay : MonoBehaviour
{
    private List<EnemyReplayRecord> enemyReplayRecords = new List<EnemyReplayRecord>();

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        enemyReplayRecords.Add(new EnemyReplayRecord(transform.position, 
            transform.eulerAngles, spriteRenderer.color));
    }

    public List<EnemyReplayRecord> getRecord()
    {
        return this.enemyReplayRecords;
    }
}