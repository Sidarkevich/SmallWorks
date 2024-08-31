using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector3 QRS => qrs;
    public CellView View => view;
    public bool IsFree { get; set; } = true;
    public bool IsObstacle { get; set; } = false;
    
    [SerializeField] private Vector3 qrs;
    [SerializeField] private CellView view;
}
