using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Spot : MonoBehaviour
{
    [HideInInspector] public UnityEvent<Color32, string> SpotTriggeredEvent = new UnityEvent<Color32, string>();

    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;

    private Color32 _color;
    private string _title;

    public void Setup(Color32 color)
    {
        _color = color;
        _image.color = _color;
    }

    public void Setup(string title)
    {
        _title = title;
        _text.text = _title;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.isTrigger)
        {
            return;
        }

        var spot = collider.GetComponent<Spot>();
        if (spot)
        {
            SpotTriggeredEvent?.Invoke(spot._color, _title);
        }
    }
}
