using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayManager : MonoBehaviour
{
    public static List<PlayerReplayRecord> playerReplayRecords;

    public static List<EnemyReplayRecord> enemyZeroRecords;
    
    public static List<EnemyReplayRecord> enemyOneRecords;
    
    public static List<EnemyReplayRecord> enemyTwoRecords;
    
    public static List<EnemyReplayRecord> enemyThreeRecords;

    public GameObject player;

    public GameObject enemyZero;
    
    public GameObject enemyOne;
    
    public GameObject enemyTwo;
    
    public GameObject enemyThree;
    
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
        
        if (enemyOneRecords == null)
        {
            enemyOneRecords = ReplaySave.enemyOneRecord;
        }
        
        if (enemyTwoRecords == null)
        {
            enemyTwoRecords = ReplaySave.enemyTwoRecord;
        }
        
        if (enemyThreeRecords == null)
        {
            enemyThreeRecords = ReplaySave.enemyThreeRecord;
        }
    }

    private void FixedUpdate()
    {
        if (counter < playerReplayRecords.Count)
        {
            SetTransform(counter);
            SetTransformEnemyZero(counter);
            SetTransformEnemyOne(counter);
            SetTransformEnemyTwo(counter);
            SetTransformEnemyThree(counter);
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
    
    private void SetTransformEnemyOne(int index)
    {
        EnemyReplayRecord record = enemyOneRecords[index];

        enemyOne.transform.position = record.getPosition();
        //player.transform.rotation = record.getRotation();
        enemyOne.transform.eulerAngles = record.getRotation();
        //enemyZero.GetComponent<SpriteRenderer>().color = record.getColor();
    }
    
    private void SetTransformEnemyTwo(int index)
    {
        EnemyReplayRecord record = enemyTwoRecords[index];

        enemyTwo.transform.position = record.getPosition();
        //player.transform.rotation = record.getRotation();
        enemyTwo.transform.eulerAngles = record.getRotation();
        //enemyZero.GetComponent<SpriteRenderer>().color = record.getColor();
    }
    
    private void SetTransformEnemyThree(int index)
    {
        EnemyReplayRecord record = enemyThreeRecords[index];

        enemyThree.transform.position = record.getPosition();
        //player.transform.rotation = record.getRotation();
        enemyThree.transform.eulerAngles = record.getRotation();
        //enemyZero.GetComponent<SpriteRenderer>().color = record.getColor();
    }
}
