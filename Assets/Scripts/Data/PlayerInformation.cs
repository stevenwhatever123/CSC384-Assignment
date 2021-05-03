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

    public PlayerInformation(PlayerStateManager player, int score)
    {
        name = PlayerData.name;
        level = LevelManager.getCurrentLevel();
        this.score = score;
        life = PlayerStateManager.numberOfLifesBefore;
        
        record = ReplaySave.record;
        enemyZeroRecord = ReplaySave.enemyZeroRecord;
    }

    public override string ToString()
    {
        string result = "Name: " + name + "\n" + "Level: " + level + "\n"
                        + "Score: " + scoreBeforePlay + "\n" + "Life: " + life + "\n";

        return result;
    }
}
