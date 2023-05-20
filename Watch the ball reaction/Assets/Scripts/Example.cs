using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _image;

    public int CurrentExample => _currentExample;
    private int _currentExample;

    private void OnEnable()
    {
        SetNewExample();
    }

    public void SetNewExample()
    {
        _currentExample = Random.Range(1,9);
        _image.sprite = _sprites[_currentExample-1];
    }
}
