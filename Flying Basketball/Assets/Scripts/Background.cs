using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private float _speed;

    private void Update()
    {
        _renderer.material.mainTextureOffset += new Vector2(_speed * Time.deltaTime * SpeedScaler.SpeedCorrection, 0);
    }
}
