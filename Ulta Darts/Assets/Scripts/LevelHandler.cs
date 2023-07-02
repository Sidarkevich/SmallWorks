using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _levelPassedEvent;
    [SerializeField] private List<LevelData> _levels;
    [SerializeField] private Animation _levelAnimation;

    private LevelData _currentLevel;
    private Transform _boardsParent;
    private Board[] _boards;
    private int _activeCount;

    public void ChangeToRandomLevel()
    {
        ChangeLevel(Random.Range(1, _levels.Count));
    }

    private void OnEnable()
    {
        ChangeLevel(0);
    }

    private void Awake()
    {
        _boardsParent = transform;
        _boards = _boardsParent.GetComponentsInChildren<Board>(true);
    }

    private void ChangeLevel(int index)
    {
        foreach (var board in _boards)
        {
            board.gameObject.SetActive(false);
        }

        _currentLevel = _levels[index];

        for (int i = 0; i < _boards.Length; i++)
        {
            var needActivate = (i < _currentLevel.ActiveCount);

            _boards[i].gameObject.SetActive(needActivate);

            if (needActivate)
            {
                _boards[i].AddDisappearedListener(OnBoardDisappeared);
            }
        }

        _levelAnimation.clip = _currentLevel.MovementClip;
        _levelAnimation.Play();
        _activeCount = _currentLevel.ActiveCount;
    }

    private void OnBoardDisappeared()
    {
        _activeCount--;

        if (_activeCount <= 0)
        {
            _levelPassedEvent?.Invoke();
        }
    }
}
