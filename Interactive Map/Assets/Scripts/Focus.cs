using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Focus : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;

    private MapObject _currentFocus;

    public void ChangeFocus(MapObject nextFocus)
    {
        _nameText.text = nextFocus.Name;
    }
}
