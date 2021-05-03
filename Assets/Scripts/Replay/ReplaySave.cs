using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySave : MonoBehaviour
{
    public PlayerReplay playerReplay;

    public static List<PlayerReplayRecord> record = new List<PlayerReplayRecord>();

    public EnemyReplay enemyZero;

    public static List<EnemyReplayRecord> enemyZeroRecord = new List<EnemyReplayRecord>();

    void Start()
    {
        enemyZero = GameObject.Find("Enemy").GetComponent<EnemyReplay>();
    }
    
    void FixedUpdate()
    {
        UpdateRecord();
    }

    void UpdateRecord()
    {
        record = playerReplay.getRecord();
        enemyZeroRecord = enemyZero.getRecord();
    }
}
