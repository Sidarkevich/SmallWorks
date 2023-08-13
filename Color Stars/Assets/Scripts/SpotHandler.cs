using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotHandler : MonoBehaviour
{
    [SerializeField] private List<Spot> _spots;
    [SerializeField] private int _startIndex;
    [SerializeField] private ColorHandler _colorHandler;

    private int _currentIndex;

    private void Start()
    {
        foreach (var spot in _spots)
        {
            spot.CollectedEvent.AddListener(OnCollected);
        }
    }

    private void OnCollected()
    {
        _currentIndex++;

        if (_currentIndex >= _spots.Count)
        {
            _currentIndex = 0;
        }

        Setup(_currentIndex);
    }

    private void Setup(int index)
    {
        _spots[_currentIndex].Setup(_colorHandler.GetRandom());

        for (int i = 0; i < _spots.Count; i++)
        {
            _spots[i].gameObject.SetActive(i != index);
        }
    }

    private void OnEnable()
    {
        _currentIndex = _startIndex;
        Setup(_currentIndex);
    }
}
