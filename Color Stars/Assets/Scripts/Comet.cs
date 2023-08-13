using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comet : MonoBehaviour
{
    [SerializeField] private SpeedHandler _speedHandler;
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private SpotHandler _spotHandler;
    [SerializeField] private Image _image;
    [SerializeField] private ColorHandler _colors;

    public Sprite CurrentSprite => _image.sprite;

    private Quaternion _startRotation;

    public void ChangeColor()
    {
        _image.sprite = _colors.GetAnotherRandom(_image.sprite);
    }

    private void OnEnable()
    {
        _speedHandler.Reset();
        _image.sprite = _colors.GetRandom();
        transform.parent.rotation = _startRotation;
    }

    private void FixedUpdate()
    {
        transform.parent.Rotate(Vector3.back * _speedHandler.CurrentSpeed, Space.World);
    }

    private void Awake()
    {
        _startRotation = transform.parent.rotation;
    }
}
