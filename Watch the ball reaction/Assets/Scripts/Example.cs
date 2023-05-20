using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    [SerializeField] private BallSpawner _spawner;
    [SerializeField] private Image _image;

    public Ball CurrentExample => _currentExample;
    private Ball _currentExample;

    public void SetNewExample()
    {
        _currentExample = _spawner.Balls[Random.Range(0, _spawner.Balls.Length)];
        _image.sprite = _currentExample.GetComponent<SpriteRenderer>().sprite;
    }
}
