using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameManager : MonoBehaviour
{
    public PlayerData playerData;

    public TMP_Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.Find("PlayerDataManager").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(playerData.GetName());
    }
}
