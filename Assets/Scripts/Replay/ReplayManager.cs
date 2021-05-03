using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayManager : MonoBehaviour
{
    public static List<PlayerReplayRecord> playerReplayRecords;

    public static List<EnemyReplayRecord> enemyZeroRecords;

    public GameObject player;

    public GameObject enemyZero;
    
    private int counter = 0;

    void Start()
    {
        if (playerReplayRecords == null)
        {
            playerReplayRecords = ReplaySave.record;
        }

        if (enemyZeroRecords == null)
        {
            enemyZeroRecords = ReplaySave.enemyZeroRecord;
        }
    }

    private void FixedUpdate()
    {
        if (counter < playerReplayRecords.Count)
        {
            SetTransform(counter);
            SetTransformEnemyZero(counter);
        }

        counter++;
    }
    
    private void SetTransform(int index)
    {
        PlayerReplayRecord record = playerReplayRecords[index];

        player.transform.position = record.getPosition();
        player.transform.eulerAngles = record.getRotation();
    }
    
    private void SetTransformEnemyZero(int index)
    {
        EnemyReplayRecord record = enemyZeroRecords[index];

        enemyZero.transform.position = record.getPosition();
        //player.transform.rotation = record.getRotation();
        enemyZero.transform.eulerAngles = record.getRotation();
        //enemyZero.GetComponent<SpriteRenderer>().color = record.getColor();
    }
}
