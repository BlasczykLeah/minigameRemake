using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[MenuItem("Inputs")]
public static class MyInputManager
{
    static Dictionary<string, KeyCode> keyMaps; // have this somewhere else
    static string[] keyNames = new string[1]
    {
        "Thing"
    };
    static KeyCode[] keys = new KeyCode[1]
    {
        KeyCode.F
    };

    static MyInputManager()
    {
        keyMaps = new Dictionary<string, KeyCode>();
        for (int i = 0; i < keyNames.Length; i++) keyMaps.Add(keyNames[i], keys[i]);
    }

    public static bool GetKeyDown(string str)
    {
        return Input.GetKeyDown(keyMaps[str]);
    }

    public static bool GetKey(string str)
    {
        return Input.GetKey(keyMaps[str]);
    }

    public static bool GetKeyUp(string str)
    {
        return Input.GetKeyUp(keyMaps[str]);
    }

    public static void SetNewKey(string str, KeyCode key)
    {
        if (keyMaps.ContainsKey(str))
        {
            keyMaps[str] = key;
        }
    }

    public static string GetKeyFromIndex(int i)
    {
        return keyNames[i];
    }
}
