using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LeaderBoardData : MonoBehaviour
{
    public GameObject panel;

    public EventSystem eventSystem;

    public int numberOfPlayerToDisplay;

    private List<PlayerInformation> arr;

    private void Awake()
    {
        arr = new List<PlayerInformation>();
    }

    void Start()
    {
        searchAllSavedData();
    }
    
    void searchAllSavedData()
    {
        string path = Application.persistentDataPath;
        foreach (string file in Directory.EnumerateFiles(path, "*.txt"))
        {
            //printdData(file);
            //Debug.Log(file);
            arr.Add(readData(file));
        }
        
        ReOrder();

        for (int i = 0; i < numberOfPlayerToDisplay; i++)
        {
            printdData(arr[i]);
        }
        
        /*
        foreach (PlayerInformation data in arr)
        {
            printdData(data);
        }
        */
    }

    void printdData(PlayerInformation data)
    {
        GameObject textObject = new GameObject("Text");
        textObject.transform.parent = panel.transform;
        Text text = textObject.AddComponent<Text>();

        text.text = data.name + "\n" + "Score: " + data.score;
        text.color = Color.black;

        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        text.font = ArialFont;
        text.material = ArialFont.material;
        text.alignment = TextAnchor.MiddleCenter;
    }

    void ReOrder()
    {
        arr = arr.OrderByDescending(o => o.score).ToList();
    }

    public PlayerInformation readData(string file)
    {
        return SaveSystem.LoadPlayer(file);
    }
}
