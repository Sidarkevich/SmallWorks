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
        Setup(_currentIndex);
    }

    private void Setup(int index)
    {
        for (int i = 0; i < _spots.Count; i++)
        {
            _spots[i].Setup(_colorHandler.GetRandom());
            _spots[i].gameObject.SetActive(i != index);
        }
    }

    private void OnEnable()
    {
        _currentIndex = _startIndex;
        Setup(_currentIndex);
    }
}
