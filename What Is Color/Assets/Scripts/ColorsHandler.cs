using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsHandler : MonoBehaviour
{
    [SerializeField] private List<Color32> _colors;
    [SerializeField] private List<string> _titles;

    [SerializeField] private List<Spot> _imageSpots;
    [SerializeField] private List<Spot> _titleSpots;
    [SerializeField] private Spot _playerSpot;

    private void OnEnable()
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
}
