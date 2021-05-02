using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI levelToDisplay;
    
    private static int currentLevel = 1;

    void Update()
    {
        levelToDisplay.text = getCurrentLevel().ToString();
    }

    public static void levelUp()
    {
        currentLevel++;
    }

    public static int getCurrentLevel()
    {
        return currentLevel;
    }
}
