using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentSpawner : MonoBehaviour
{
    [SerializeField] private List<FragmentData> _dataList;
    [SerializeField] private Fragment _prefab;

    public Fragment Spawn()
    {
        var fragment = Instantiate(_prefab, Vector3.zero, Quaternion.identity, transform);
        fragment.Init(_dataList[Random.Range(0, _dataList.Count)]);
        return fragment;
    }
}
