using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int TypeIndex => _typeIndex;
    [SerializeField] private int _typeIndex;

    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);
    }
}
