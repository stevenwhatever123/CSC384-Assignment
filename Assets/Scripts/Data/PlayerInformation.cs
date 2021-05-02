using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInformation
{
    public string name;
    public int level;
    public int score;
    public int life;

    public PlayerInformation(PlayerStateManager player, Vector3 playerPosition)
    {
        name = PlayerData.name;
        level = LevelManager.getCurrentLevel();
        score = ScoreManager.getScoreBeforePlay();
        life = player.GetNumberOfLife();
    }

    public override string ToString()
    {
        string result = "Name: " + name + "\n" + "Level: " + level + "\n"
                        + "Score: " + score + "\n" + "Life: " + life + "\n";

        return result;
    }
}
