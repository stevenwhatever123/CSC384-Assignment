using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameHandler : MonoBehaviour
{
    public Text text;
    
    private Animator animator;

    public float transitionTime = 1f;
    
    void Start()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }
    
    void Update()
    {
        Color();
    }
    
    public void LoadGame()
    {
        StartCoroutine(Transition());
        Debug.Log("Load Game");
    }

    public void Color()
    {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject)
        {   
            text.color = UnityEngine.Color.yellow;
        }
        else
        {
            text.color = UnityEngine.Color.white;
        }
    }
    
    IEnumerator Transition()
    {
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("LoadGameScene", LoadSceneMode.Single);
    }
}