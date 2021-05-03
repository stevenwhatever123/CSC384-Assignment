using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSaveData : MonoBehaviour
{
    private Animator animator;

    public float transitionTime = 1f;
    
    public PlayerInformation data;
    
    void Start()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    public void AddData(PlayerInformation data)
    {
        this.data = data;
    }

    public PlayerInformation GetData()
    {
        return this.data;
    }

    public void OnClick()
    {
        StartCoroutine(TransitionToLoadGame());
    }

    public void LoadGame()
    {
        PlayerData.name = data.name;
        LevelManager.setCurrentLevel(data.level);
        ScoreManager.setScore(data.score);
        PlayerStateManager.numberOfLifes = data.life;
    }
    
    IEnumerator TransitionToLoadGame()
    {
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(transitionTime);
        LoadGame();
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
    
    void PlayReplay()
    {
        string path = Application.persistentDataPath + "/Replay/" + data.name + ".txt";
        if (File.Exists(path))
        {
            PlayerInformation record = SaveSystem.LoadReplay(path);
            
            ReplaySave.record = record.record;
            ReplayManager.playerReplayRecords = record.record;
            ReplayManager.enemyZeroRecords = record.enemyZeroRecord;
            PlayerStateManager.numberOfLifes = record.life;
            PlayerData.name = data.name;
            ScoreManager.setScore(record.scoreBeforePlay);
            LevelManager.setCurrentLevel(data.level-1);
                
            StartCoroutine(TransitionToReplay());
            //SceneManager.LoadScene("ReplayScene", LoadSceneMode.Single);
        }
        else
        {
            Debug.Log("Replay does not exist");
        }
    }

    public void OnClickLeaderBoard()
    {
        PlayReplay();
    }

    IEnumerator TransitionToReplay()
    {
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("ReplayScene", LoadSceneMode.Single);
    }
}
