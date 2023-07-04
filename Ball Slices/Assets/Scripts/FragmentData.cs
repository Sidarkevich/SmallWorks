using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FragmentData", menuName = "ScriptableObjects/FragmentData")]
public class FragmentData : ScriptableObject
{
    [SerializeField] private List<int> _fragmentPositions;

    public int ScoreValue => _fragmentPositions.Count;
    public IEnumerable<int> FragmentPositions => _fragmentPositions;
}
