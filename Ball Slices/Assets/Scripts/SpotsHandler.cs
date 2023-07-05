using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotsHandler : MonoBehaviour
{
    [SerializeField] private List<SpotInput> _inputs = new List<SpotInput>();
    [SerializeField] private Spot _centralSpot;
    [SerializeField] private Spot _nextSpot;
    [SerializeField] private FragmentSpawner _spawner;
    [SerializeField] private ScoreHandler _score;

    private List<Spot> _spots = new List<Spot>();

    private void OnEnable()
    {
        foreach (var spot in _inputs)
        {
            spot.ClickedEvent.AddListener(OnClicked);
            spot.Spot.FullOfFragmentsEvent.AddListener(OnFullOfFragments);
            spot.Spot.FragmentAddedEvent.AddListener(OnFragmentAdded);
            _spots.Add(spot.Spot);
        }

        _nextSpot.AddFragment(_spawner.Spawn(), false);
        _centralSpot.AddFragment(_spawner.Spawn(), false);
    }

    private void OnDisable()
    {
        foreach (var spot in _inputs)
        {
            spot.ClickedEvent.RemoveListener(OnClicked);
            spot.Spot.FullOfFragmentsEvent.RemoveListener(OnFullOfFragments);
            spot.Spot.FragmentAddedEvent.RemoveListener(OnFragmentAdded);
        }

        Clear();
    }

    private void OnClicked(Spot clicked)
    {
        var fragment = _centralSpot.GetFirst;

        if (clicked.CanBeAdded(fragment))
        {
            _centralSpot.RemoveFragment(fragment);
            clicked.AddFragment(fragment, true);

            fragment = _nextSpot.GetFirst;
            _nextSpot.RemoveFragment(fragment);
            _centralSpot.AddFragment(fragment, false);
            fragment.Appear();

            if (!CanBeAddedToAny(fragment))
            {
                _score.Loss();
                return;
            }

            _nextSpot.AddFragment(_spawner.Spawn(), false);
        }
    }

    private void OnFullOfFragments(Spot filled)
    {
        var currentIndex = _spots.FindIndex(a => a == filled);

        var nextIndex = (currentIndex == _spots.Count-1 ? 0 : currentIndex+1);
        var prevIndex = (currentIndex == 0 ? _spots.Count-1 : currentIndex-1);

        var total = _spots[currentIndex].TotalScore + _spots[nextIndex].TotalScore + _spots[prevIndex].TotalScore;

        _spots[currentIndex].Clear(true);
        _spots[nextIndex].Clear(true);
        _spots[prevIndex].Clear(true);

        _score.IncreaseScore(total);
    }

    private void OnFragmentAdded()
    {
        _score.IncreaseScore(1);
    }

    private bool CanBeAddedToAny(Fragment fragment)
    {
        foreach (var spot in _spots)
        {
            if (spot.CanBeAdded(fragment))
            {
                return true;
            }
        }

        return false;
    }

    private void Clear()
    {
        _centralSpot.Clear(false);
        _nextSpot.Clear(false);

        foreach (var spot in _spots)
        {
            spot.Clear(false);
        }
        _spots.Clear();
    }
}
