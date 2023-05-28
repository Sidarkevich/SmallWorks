using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelCondition[] _levels;
    [SerializeField] private Sprite[] _levelIcons;
    [SerializeField] private Transform _levelsParent;

    [SerializeField] private Image _levelImage;

    private LevelCondition _currentLevel;
    private int _currentIndex;

    public void LoadCurrentLevel()
    {
        LoadLevel(_currentIndex);
    }

    public void LoadLevel(int index)
    {
        if (_currentLevel)
        {
            _currentLevel.LevelCompletedEvent.RemoveListener(OnLevelCompleted);
            _currentLevel.LevelFailedEvent.RemoveListener(OnLevelFailed);

            Destroy(_currentLevel.gameObject);
        }

        _currentLevel = Instantiate(_levels[index], Vector3.zero, Quaternion.identity, _levelsParent);

        _currentLevel.LevelCompletedEvent.AddListener(OnLevelCompleted);
        _currentLevel.LevelFailedEvent.AddListener(OnLevelFailed);

        _levelImage.sprite = _levelIcons[index];
    }

    private void Start()
    {
        LoadLevel(0);
    }

    private void OnLevelCompleted()
    {
        _currentIndex++;

        if (_currentIndex == _levels.Length)
        {
            Debug.Log("To menu!");
            // END GAME TO MENU
            return;
        }

        LoadLevel(_currentIndex);
    }

    private void OnLevelFailed()
    {
        LoadCurrentLevel();
    }
}
