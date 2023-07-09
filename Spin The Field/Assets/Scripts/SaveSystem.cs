using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public const int ClosedLevelStatus = -1;
    public const int OpenedLevelStatus = 1;

    public static void SaveLevelStatus(int levelIndex, int status)
    {
        PlayerPrefs.SetInt($"Level{levelIndex}", status);
        PlayerPrefs.Save();
    }

    public static int LoadLevelStatus(int levelIndex)
    {
        return PlayerPrefs.GetInt($"Level{levelIndex}", ClosedLevelStatus);
    }
}
