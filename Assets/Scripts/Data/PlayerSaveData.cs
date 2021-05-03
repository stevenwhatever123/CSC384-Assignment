using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine(Transition());
    }

    public void LoadGame()
    {
        PlayerData.name = data.name;
        LevelManager.setCurrentLevel(data.level);
        ScoreManager.setScore(data.score);
        PlayerStateManager.numberOfLifes = data.life;
    }
    
    IEnumerator Transition()
    {
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(transitionTime);
        LoadGame();
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
