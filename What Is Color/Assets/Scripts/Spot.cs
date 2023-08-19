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
    private bool _isSetupped;

    public void Setup(Color32 color)
    {
        _color = color;
        _image.color = _color;
        _isSetupped = true;
    }

    public void Setup(string title)
    {
        _title = title;
        _text.text = _title;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!_isSetupped)
            return;

        if (collider.isTrigger)
            return;

        var spot = collider.GetComponent<Spot>();
        if (spot)
        {
            _isSetupped = false;
            SpotTriggeredEvent?.Invoke(spot._color, _title);
        }
    }
}
