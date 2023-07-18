using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _parallaxSpeed;

    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _meshRenderer.material.mainTextureOffset += new Vector2(0, _parallaxSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _meshRenderer.material.mainTextureOffset = Vector2.zero;
    }
}
