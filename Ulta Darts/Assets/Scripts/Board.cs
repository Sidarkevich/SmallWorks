using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Animation _disappearance;

    public void Disappear()
    {
        _disappearance.Play();
    }
}
