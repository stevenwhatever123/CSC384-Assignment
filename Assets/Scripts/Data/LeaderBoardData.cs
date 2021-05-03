using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LeaderBoardData : MonoBehaviour
{
    public GameObject panel;

    public EventSystem eventSystem;

    private int counter = 0;

    void Start()
    {
        searchAllSavedData();
    }
    
    void searchAllSavedData()
    {
        string path = Application.persistentDataPath;
        foreach (string file in Directory.EnumerateFiles(path, "*.txt"))
        {
            printdData(file);
            //Debug.Log(file);
            counter++;
        }
    }

    void printdData(string name)
    {
        PlayerInformation data = readData(name);

        GameObject buttonObject = new GameObject("Button");
        CanvasRenderer canvasRenderer = buttonObject.AddComponent<CanvasRenderer>();
        Image image = buttonObject.AddComponent<Image>();
        Button button = buttonObject.AddComponent<Button>();
        buttonObject.transform.parent = panel.transform;

        VerticalLayoutGroup layout = buttonObject.AddComponent<VerticalLayoutGroup>();
        layout.childControlWidth = true;
        layout.childControlHeight = true;

        layout.childForceExpandHeight = true;
        layout.childForceExpandWidth = true;

        ColorBlock cb = button.colors;
        cb.selectedColor = Color.yellow;
        button.colors = cb;
        PlayerSaveData saveFile = buttonObject.AddComponent<PlayerSaveData>();
        saveFile.AddData(data);

        button.onClick.AddListener(saveFile.OnClick);

        GameObject textObject = new GameObject("Text");
        textObject.transform.parent = buttonObject.transform;
        Text text = textObject.AddComponent<Text>();

        text.text = data.ToString();
        text.color = Color.black;
        
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        text.font = ArialFont;
        text.material = ArialFont.material;

        if (counter == 0)
        {
            eventSystem.firstSelectedGameObject = buttonObject;
        }
    }

    public PlayerInformation readData(string file)
    {
        return SaveSystem.LoadPlayer(file);
    }
}
