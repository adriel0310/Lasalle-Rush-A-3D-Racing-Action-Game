using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsUtility
{
    public static void SaveVector3(string key, Vector3 value)
    {
        PlayerPrefs.SetFloat(key + "X", value.x);
        PlayerPrefs.SetFloat(key + "Y", value.y);
        PlayerPrefs.SetFloat(key + "Z", value.z);
    }

    public static Vector3 LoadVector3(string key)
    {
        Vector3 value = new Vector3();
        value.x = PlayerPrefs.GetFloat(key + "X");
        value.y = PlayerPrefs.GetFloat(key + "Y");
        value.z = PlayerPrefs.GetFloat(key + "Z");
        return value;
    }
}
