using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public TextMeshProUGUI lifeToDisplay;

    private PlayerStateManager playerStateManager;

    private int life = 3;
    
    void Start()
    {
        playerStateManager = GetComponent<PlayerStateManager>();
        lifeToDisplay = GameObject.Find("NumberOfLife").GetComponent<TextMeshProUGUI>();
        UpdateLifesFromManager();
        lifeToDisplay.text = getLifes().ToString();
    }
    
    void Update()
    {
        UpdateLifesFromManager();
        lifeToDisplay.text = getLifes().ToString();
    }

    public void UpdateLifesFromManager()
    {
        this.life = playerStateManager.GetNumberOfLife();
    }

    public int getLifes()
    {
        return this.life;
    }

    public void setLife(int life)
    {
        this.life = life;
    }
}
