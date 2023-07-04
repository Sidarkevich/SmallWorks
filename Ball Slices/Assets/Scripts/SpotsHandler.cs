using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotsHandler : MonoBehaviour
{
    [SerializeField] private List<SpotInput> _spots = new List<SpotInput>();
    [SerializeField] private Spot _centralSpot;
    [SerializeField] private Spot _nextSpot;
    [SerializeField] private FragmentSpawner _spawner;

    private void OnEnable()
    {
        foreach (var spot in _spots)
        {
            spot.ClickedEvent.AddListener(OnClicked);
        }

        _nextSpot.AddFragment(_spawner.Spawn());
        _centralSpot.AddFragment(_spawner.Spawn());
    }

    private void OnDisable()
    {
        foreach (var spot in _spots)
        {
            spot.ClickedEvent.RemoveListener(OnClicked);
        }
    }

    private void OnClicked(Spot clicked)
    {
        var fragment = _centralSpot.GetFirst;

        if (clicked.CanBeAdded(fragment))
        {
            _centralSpot.RemoveFragment(fragment);
            clicked.AddFragment(fragment);

            fragment = _nextSpot.GetFirst;
            _nextSpot.RemoveFragment(fragment);
            _centralSpot.AddFragment(fragment);

            _nextSpot.AddFragment(_spawner.Spawn());
        }
    }
}
