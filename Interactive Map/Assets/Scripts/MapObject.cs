using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour
{
    public int ObjectTypeIndex => _objectTypeIndex;
    public int ReserveIndex => _reserveIndex;
    public string Name => _name;
    public Sprite Label => _label;
    public int Square => _square;
    public int YearFoundation => _yearFoundation;

    [SerializeField] private int _objectTypeIndex;
    [SerializeField] private int _reserveIndex;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _label;
    [SerializeField] private int _square;
    [SerializeField] private int _yearFoundation;

    [SerializeField] private Focus _focus;

    private void OnMouseUpAsButton()
    {
        _focus.ChangeFocus(this);
    }
}
