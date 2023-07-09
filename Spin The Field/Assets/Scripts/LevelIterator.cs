using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelIterator : MonoBehaviour
{
    [SerializeField] private List<LevelData> _levels;
    [SerializeField] private Transform _levelsRoot;
    
    private LevelData _current;
    private LevelCondition _level;

    public void SetCurrent(int index)
    {
        if (_current)
        {
            Destroy(_level.gameObject);
        }

        if (_levels[index])
        {
            _current = _levels[index];
            _level = Instantiate(_current.Prefab, _levelsRoot); 
        }
    }
}
