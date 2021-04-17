using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public TextMeshProUGUI lifeToDisplay;

    private int life = 3;
    
    void Start()
    {
        lifeToDisplay = GameObject.Find("NumberOfLife").GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        lifeToDisplay.text = getLifes().ToString();
    }

    public int getLifes()
    {
        return life;
    }

    public void setLife(int life)
    {
        this.life = life;
    }
}
