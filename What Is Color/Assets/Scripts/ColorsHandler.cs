using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorsHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _sameColorsEvent;
    [SerializeField] private UnityEvent _differentColorsEvent;

    [SerializeField] private List<Color32> _colors;
    [SerializeField] private List<string> _titles;

    [SerializeField] private List<Spot> _imageSpots;
    [SerializeField] private List<Spot> _titleSpots;
    [SerializeField] private Spot _playerSpot;

    [SerializeField] private DragInput _input;

    public void Setup()
    {
        var colors = new List<Color32>(_colors);
        colors.Shuffle();
        for (int i = 0; i < _imageSpots.Count; i++)
        {
            _imageSpots[i].Setup(colors[i]);
        }

        var titles = new List<string>(_titles);
        titles.Shuffle();
        for (int i = 0; i < _titleSpots.Count; i++)
        {
            _titleSpots[i].Setup(titles[i]);
        }

        _playerSpot.Setup(colors[Random.Range(0, colors.Count)]);
    }

    private void Awake()
    {
        foreach (var spot in _titleSpots)
        {
            spot.SpotTriggeredEvent.AddListener(OnSpotTriggered);
        }
    }

    private void OnSpotTriggered(Color32 color, string title)
    {
        var colorIndex = _colors.FindIndex(a => ((a.r == color.r) && (a.g == color.g) && (a.b == color.b)));
        var titleIndex = _titles.FindIndex(a => a == title);
        
        _input.Setup();
        Setup();

        if (colorIndex == titleIndex)
        {
            _sameColorsEvent?.Invoke();
        }
        else
        {
            _differentColorsEvent?.Invoke();
        }
    }
}
