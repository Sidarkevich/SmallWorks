using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector3 QRS => qrs;
    public CellView View => view;
    
    [SerializeField] private Vector3 qrs;
    [SerializeField] private CellView view;
}
