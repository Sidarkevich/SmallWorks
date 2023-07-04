using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotsHandler : MonoBehaviour
{
    [SerializeField] private List<SpotInput> _spots = new List<SpotInput>();
    [SerializeField] private Spot _centralSpot;
    [SerializeField] private Spot _nextSpot;

    private void OnEnable()
    {
        foreach (var spot in _spots)
        {
            spot.ClickedEvent.AddListener(OnClicked);
        }
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
        Debug.Log("Clicked!");
    }
}
