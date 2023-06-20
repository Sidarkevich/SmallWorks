using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private float _startSpeed;

    private float _lowSpeed;
    private float _speed;

    private void Start()
    {
        _speed = _startSpeed;
        _lowSpeed = _speed / 4;
    }

    private void Update()
    {
        _renderer.material.mainTextureOffset += new Vector2(_speed * Time.deltaTime, 0);
    }
}
