using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector3 QRS => qrs;
    public CellView View => view;
    public bool IsObstacle => isObstacle;
    
    public bool IsFree { get; set; } = true;
    
    [SerializeField] private Vector3 qrs;
    [SerializeField] private CellView view;
    [SerializeField] private bool isObstacle;
}
