using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject collectables;

    public PlayerStateManager player;

    private int numOfCollectables;

    public static bool inReplayMode = false;
    
    // Start is called before the first frame update
    void Start()
    {
        numOfCollectables = collectables.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCollectablesCount();
        if (numOfCollectables == 0)
        {
            if (!inReplayMode)
            {
                LevelManager.levelUp();
                SaveSystem.SaveReplay(player, ScoreManager.getScore());
                SaveSystem.SavePlayer(player, ScoreManager.getScore());
                inReplayMode = true;
                SceneManager.LoadScene("ReplayScene", LoadSceneMode.Single);
            }
        }
        //Debug.Log("Count: " + numOfCollectables);
    }

    void UpdateCollectablesCount()
    {
        numOfCollectables = collectables.transform.childCount;
    }

    public int getNumOfCollectables()
    {
        return numOfCollectables;
    }
}
