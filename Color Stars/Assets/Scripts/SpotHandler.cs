using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotHandler : MonoBehaviour
{
    [SerializeField] private List<Spot> spots;
    [SerializeField] private int _startIndex;

    private void OnEnable()
    {
        for (int i = 0; i < spots.Count; i++)
        {

        }
    }
}
