using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUnlocker : MonoBehaviour
{
    [SerializeField] private int _unlockValue;
    [SerializeField] private Image _lockImage;
    [SerializeField] private Image _unlockImage;

    private void OnEnable()
    {
        var value = PlayerPrefs.GetInt("TotalScore", 0);

        var isUnlocked = (_unlockValue <= value);

        _lockImage.gameObject.SetActive(!isUnlocked);
        _unlockImage.gameObject.SetActive(isUnlocked);
    }
}
