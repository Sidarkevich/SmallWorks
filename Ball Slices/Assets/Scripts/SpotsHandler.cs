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
        }

        _spots.Clear();
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

            var newFragment = _spawner.Spawn();
            _nextSpot.AddFragment(newFragment, false);

            if (!CanBeAddedToAny(newFragment))
            {
                _score.Loss();
            }
        }
    }

    private void OnFullOfFragments(Spot filled)
    {
        var currentIndex = _spots.FindIndex(a => a == filled);

        var nextIndex = (currentIndex == _spots.Count-1 ? 0 : currentIndex+1);
        var prevIndex = (currentIndex == 0 ? _spots.Count-1 : currentIndex-1);

        var total = _spots[currentIndex].TotalScore + _spots[nextIndex].TotalScore + _spots[prevIndex].TotalScore;

        _spots[currentIndex].Clear();
        _spots[nextIndex].Clear();
        _spots[prevIndex].Clear();

        _score.IncreaseScore(total);
    }

    private bool CanBeAddedToAny(Fragment fragment)
    {
        bool result = true;

        foreach (var spot in _spots)
        {
            if (!spot.CanBeAdded(fragment))
            {
                result = false;
            }
        }

        return result;
    }
}
