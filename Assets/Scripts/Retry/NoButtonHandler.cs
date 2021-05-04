using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NoButtonHandler : MonoBehaviour
{
    public EventSystem eventSystem;
    
    private Animator animator;
    
    public float transitionTime = 1f;

    void Start()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    public void Exit()
    {
        ScoreManager.setScore(0);
        PlayerStateManager.numberOfLifes = PlayerStateManager.numberOfLifesBefore;
        StartCoroutine(Transition());
    }
    
    IEnumerator Transition()
    {
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}