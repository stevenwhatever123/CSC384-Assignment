using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInformation
{
    public string name;
    public int level;
    public int scoreBeforePlay;
    public int score;
    public int life;
    public List<PlayerReplayRecord> record;
    public List<EnemyReplayRecord> enemyZeroRecord;
    public List<EnemyReplayRecord> enemyOneRecord;
    public List<EnemyReplayRecord> enemyTwoRecord;
    public List<EnemyReplayRecord> enemyThreeRecord;

    public PlayerInformation(PlayerStateManager player, int score)
    {
        name = PlayerData.name;
        level = LevelManager.getCurrentLevel();
        this.score = score;
        life = PlayerStateManager.numberOfLifesBefore;

        record = ReplaySave.record;
        enemyZeroRecord = ReplaySave.enemyZeroRecord;
        enemyOneRecord = ReplaySave.enemyOneRecord;
        enemyTwoRecord = ReplaySave.enemyTwoRecord;
        enemyThreeRecord = ReplaySave.enemyThreeRecord;
    }

    public override string ToString()
    {
        string result = "Name: " + name + "\n" + "Level: " + level + "\n"
                        + "Score: " + scoreBeforePlay + "\n" + "Life: " + life + "\n";

        return result;
    }
}
