using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private Tableau _tableau;

    private void OnMouseUpAsButton()
    {
        _tableau.AddCard(this);
    }
}
