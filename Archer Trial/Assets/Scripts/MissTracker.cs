using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Setup(int first, int second)
    {
        _text.text = $"{first}/{second}";
    }
}
