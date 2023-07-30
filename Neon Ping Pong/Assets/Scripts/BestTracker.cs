using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestTracker : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    public void OnBestResultUpdate()
    {
        Setup();
    }

    private void OnEnable()
    {
        Setup();
    }

    private void Setup()
    {
        _text.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }
}
