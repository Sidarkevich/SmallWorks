using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private float _animationSpeed;

    void Update()
    {
        _renderer.material.mainTextureOffset += new Vector2(_animationSpeed * Time.deltaTime, 0);
    }
}
