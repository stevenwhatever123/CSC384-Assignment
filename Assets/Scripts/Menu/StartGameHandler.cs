using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StartGameHandler : MonoBehaviour
{
    public PlayerData playerData;

    public TMP_InputField inputField;
    
    public TMP_Text text;

    public TMP_Text alertText;

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
    
    public void StartGame()
    {
        if (inputField.text != "")
        {
            alertText.color = new Color(1, 0, 0, 0);
            alertText.enabled = false;
            playerData.SetName(inputField.text);
            TutorialManager.firstTimePlaying = true;
            StartCoroutine(Transition());
            Debug.Log("Start Game");
        }

        alertText.color = new Color(1, 0, 0, 1);
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
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}