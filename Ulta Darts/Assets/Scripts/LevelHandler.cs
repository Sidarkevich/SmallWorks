using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private List<LevelData> _levels;
    [SerializeField] private Animation _levelAnimation;

    private LevelData _currentLevel;
    private Transform _boardsParent;
    private Board[] _boards;

    private void OnEnable()
    {
        ChangeLevel(0);
    }

    private void Awake()
    {
        _boardsParent = transform;
        _boards = _boardsParent.GetComponentsInChildren<Board>();
    }

    private void ChangeLevel(int index)
    {
        _currentLevel = _levels[index];

        for (int i = 0; i < _boards.Length; i++)
        {
            _boards[i].gameObject.SetActive(i < _currentLevel.ActiveCount);
        }

        _levelAnimation.clip = _currentLevel.MovementClip;
        _levelAnimation.Play();
    }
}
