using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySave : MonoBehaviour
{
    public PlayerReplay playerReplay;

    public static List<PlayerReplayRecord> record = new List<PlayerReplayRecord>();

    public EnemyReplay enemyZero;

    public static List<EnemyReplayRecord> enemyZeroRecord = new List<EnemyReplayRecord>();
    
    public EnemyReplay enemyOne;

    public static List<EnemyReplayRecord> enemyOneRecord = new List<EnemyReplayRecord>();
    
    public EnemyReplay enemyTwo;

    public static List<EnemyReplayRecord> enemyTwoRecord = new List<EnemyReplayRecord>();
    
    public EnemyReplay enemyThree;

    public static List<EnemyReplayRecord> enemyThreeRecord = new List<EnemyReplayRecord>();

    void Start()
    {
        enemyZero = GameObject.Find("Enemy").GetComponent<EnemyReplay>();
        enemyOne = GameObject.Find("Enemy (1)").GetComponent<EnemyReplay>();
        enemyTwo = GameObject.Find("Enemy (2)").GetComponent<EnemyReplay>();
        enemyThree = GameObject.Find("Enemy (3)").GetComponent<EnemyReplay>();
    }
    
    void FixedUpdate()
    {
        UpdateRecord();
    }

    void UpdateRecord()
    {
        record = playerReplay.getRecord();
        enemyZeroRecord = enemyZero.getRecord();
        enemyOneRecord = enemyOne.getRecord();
        enemyTwoRecord = enemyTwo.getRecord();
        enemyThreeRecord = enemyThree.getRecord();
    }
}
