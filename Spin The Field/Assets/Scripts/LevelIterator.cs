using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class LevelIterator : MonoBehaviour
{
    public UnityEvent GamePassedEvent;
    public UnityEvent LevelPassedEvent;

    [SerializeField] private List<LevelData> _levels;
    [SerializeField] private Transform _levelsRoot;
    [SerializeField] private TMP_Text _indexText;
    
    private LevelData _current;
    private LevelCondition _level;

    public void SetCurrent(int index)
    {
        if (_current)
        {
            _level.PassedEvent.RemoveListener(OnPassed);
            _level.LostEvent.RemoveListener(OnLost);
            Destroy(_level.gameObject);
        }

        if (_levels[index])
        {
            _current = _levels[index];
            _current.OpenLevel();
            _level = Instantiate(_current.Prefab, _levelsRoot);
            _indexText.text = (index+1).ToString();
            _levelsRoot.rotation = new Quaternion();

            _level.PassedEvent.AddListener(OnPassed);
            _level.LostEvent.AddListener(OnLost);
        }
    }

    private void OnPassed()
    {
        LevelPassedEvent?.Invoke();

        if (_current.Index == _levels.Count-1)
        {
            GamePassedEvent?.Invoke();
            return;
        }

        SetCurrent(_current.Index+1);
    }

    private void OnLost()
    {
        SetCurrent(_current.Index);
    }
}
