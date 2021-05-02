using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NewGameHandler : MonoBehaviour
{
    public Text text;
    
    void Update()
    {
        Color();
    }
    
    public void CreateNewGame()
    {
        Debug.Log("New Game");
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
