using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    public Board Board => _board;
    public int HitValue => _hitValue;

    [SerializeField] private Board _board;
    [SerializeField] private int _hitValue;
}
