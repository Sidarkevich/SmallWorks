using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    private void OnEnable()
    {
        var maxIndx = PlayerPrefs.GetInt("MaxLevel", 0);

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = (i <= maxIndx);
        }
    }
}
