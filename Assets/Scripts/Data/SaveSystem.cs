using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerStateManager player, int score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        PlayerInformation data = new PlayerInformation(player, score);
        
        //string path = Application.persistentDataPath + "/player.txt";
        string path = Application.persistentDataPath + "/" + data.name + ".txt";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        FileStream stream = new FileStream(path, FileMode.Create);
        
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Saved at: " + path);
        Debug.Log(data);
    }
    
    public static void SavePlayerAfterComplete(PlayerStateManager player, int score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        PlayerInformation data = new PlayerInformation(player, score);

        data.score = score;
        data.scoreBeforePlay = score;

        //string path = Application.persistentDataPath + "/player.txt";
        string path = Application.persistentDataPath + "/" + data.name + ".txt";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        FileStream stream = new FileStream(path, FileMode.Create);
        
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Saved at: " + path);
        Debug.Log(data);
    }
    
    public static void SaveReplay(PlayerStateManager player, int score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        PlayerInformation data = new PlayerInformation(player, score);
        
        //string path = Application.persistentDataPath + "/player.txt";
        string path = Application.persistentDataPath + "/Replay/" + data.name + ".txt";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        FileStream stream = new FileStream(path, FileMode.Create);
        
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Saved at: " + path);
        Debug.Log(data);
    }

    public static PlayerInformation LoadPlayer(string name)
    {
        //string path = Application.persistentDataPath + "/" + name + ".txt";
        string path = name;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerInformation data = formatter.Deserialize(stream) as PlayerInformation;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    
    public static PlayerInformation LoadReplay(string name)
    {
        //string path = Application.persistentDataPath + "/" + name + ".txt";
        string path = name;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerInformation data = formatter.Deserialize(stream) as PlayerInformation;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
