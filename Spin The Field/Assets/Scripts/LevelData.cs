using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int _index;
    [SerializeField] private bool _isOpen;
    [SerializeField] private GameObject _prefab;

    public int Index => _index;
    public bool IsOpen => _isOpen;
    public GameObject Prefab => _prefab;
}
