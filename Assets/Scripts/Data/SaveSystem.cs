using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerStateManager player, Vector3 position)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        PlayerInformation data = new PlayerInformation(player, position);
        
        //string path = Application.persistentDataPath + "/player.txt";
        string path = Application.persistentDataPath + "/" + data.name + ".txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Saved at: " + path);
        Debug.Log(data);
    }

    public static PlayerInformation LoadPlayer(string name)
    {
        string path = Application.persistentDataPath + "/" + name + ".txt";
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
