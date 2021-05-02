using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static string name = "John";

    public void SetName(string n)
    {
        name = n;
    }

    public string GetName()
    {
        return name;
    }
}
