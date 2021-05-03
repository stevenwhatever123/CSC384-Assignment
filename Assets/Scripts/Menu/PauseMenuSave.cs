using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenuSave : MonoBehaviour
{
    public Button button;

    public PlayerStateManager player;

    public Transform playerPosition;
    
    void Update()
    {
        Color();
    }
    
    public void Color()
    {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject)
        {   
            button.image.color = UnityEngine.Color.yellow;
        }
        else
        {
            button.image.color = UnityEngine.Color.white;
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player, ScoreManager.getScoreBeforePlay());
    }
}
