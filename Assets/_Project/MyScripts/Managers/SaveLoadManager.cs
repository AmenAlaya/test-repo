using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager 
{
    public static object Load(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public static void Save(string key, object value)
    {
        PlayerPrefs.SetInt(key, (int)value);
    }
}
