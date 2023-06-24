using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private float _yMax;
    private float _yMin;
    private float _xSpawn;

    private Ring _lastRing;

    private void Awake()
    {
        var mainCamera = Camera.main;

        var xPos = mainCamera.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth*0.55f, Camera.main.pixelHeight, 0)).x;

        _yMin = mainCamera.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight*0.25f, 0)).y;
        _yMax = mainCamera.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight*(1f - 0.35f), 0)).y;
        _xSpawn = mainCamera.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth + 50, 0, 0)).x;

        transform.position = new Vector3(xPos, 0, transform.position.z);
    }

    private void OnEnable()
    {
        Spawn();
    }

    private void Spawn()
    {
        var yPosition = Random.Range(_yMin, _yMax);
        Instantiate(_prefab, new Vector3(_xSpawn, yPosition, transform.position.z), Quaternion.identity, transform);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var ring = collider.GetComponentInParent<Ring>();

        if ((ring) && (ring != _lastRing))
        {
            Spawn();
            _lastRing = ring;
        }
    }
}
