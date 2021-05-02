using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NewGameHandler : MonoBehaviour
{
    public Text text;

    public Animator animator;

    public float transitionTime = 1f;

    void Start()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }
    
    void Update()
    {
        Color();
    }
    
    public void CreateNewGame()
    {
        StartCoroutine(Transition());
        Debug.Log("New Game");
    }

    IEnumerator Transition()
    {
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("NewGameMenu", LoadSceneMode.Single);
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
}
