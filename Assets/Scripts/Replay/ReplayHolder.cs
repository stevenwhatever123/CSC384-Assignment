using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayHolder : MonoBehaviour
{
    public PlayerInformation data;

    public void setData(PlayerInformation data)
    {
        this.data = data;
    }

    public PlayerInformation getData()
    {
        return this.data;
    }
    
    void CheckIfReplayExist()
    {
        string path = Application.persistentDataPath + "/Replay/" + data.name + ".txt";
        if (File.Exists(path))
        {
            PlayerInformation record = SaveSystem.LoadReplay(path);
            ReplaySave.record = record.record;
            SceneManager.LoadScene("ReplayScene", LoadSceneMode.Single);
        }
        else
        {
            Debug.Log("Replay does not exist");
        }
    }

    public void OnClick()
    {
        CheckIfReplayExist();
    }
}
