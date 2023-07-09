using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private LevelIterator _iterator;
    [SerializeField] private LevelData _level;
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;

    public void LoadLevel()
    {
        _iterator.SetCurrent(_level.Index);
    }

    private void Awake()
    {
        _image.sprite = _level.Sprite;
    }

    private void OnEnable()
    {
        SetActive(_level.IsOpen);
    }

    private void SetActive(bool state)
    {
        _button.interactable = state;
    }
}
