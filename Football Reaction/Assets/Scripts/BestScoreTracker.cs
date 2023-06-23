using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScoreTracker : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    private void OnEnable()
    {
        _text.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }
}