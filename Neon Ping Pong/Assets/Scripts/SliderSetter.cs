using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSetter : MonoBehaviour
{
    public enum Direction
    {
        Positive = 1,
        Negative = -1
    }

    [SerializeField] private List<Slider> _sliders;
    [SerializeField] private float _changeRate;

    private float _value;
    private Direction _direction = Direction.Negative;

    public void ChangeDirection(Direction direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        _value += (int)_direction * _changeRate * Time.deltaTime;

        _value = Mathf.Max(0, _value);
        _value = Mathf.Min(1, _value);

        UpdateSliders();
    }

    private void UpdateSliders()
    {
        foreach (var slider in _sliders)
        {
            slider.value = _value;
        }
    }
}
