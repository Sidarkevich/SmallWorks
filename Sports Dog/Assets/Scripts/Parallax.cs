using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _parallaxSpeed;
    [SerializeField] private RawImage _image;

    private void Update()
    {
        _image.uvRect = new Rect(_image.uvRect.position + new Vector2(_parallaxSpeed, 0) * Time.deltaTime, _image.uvRect.size);
    }

    private void OnEnable()
    {
        _image.uvRect = new Rect(_image.uvRect);
    }
}
