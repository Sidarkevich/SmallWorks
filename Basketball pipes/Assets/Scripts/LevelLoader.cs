using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] _levels;
    [SerializeField] private Transform _levelsParent;

    private GameObject _currentLevel;

    public void LoadLevel(int index)
    {
        if (_currentLevel)
        {
            Destroy(_currentLevel);
        }

        Instantiate(_levels[index], Vector3.zero, Quaternion.identity, _levelsParent);
    }
}
