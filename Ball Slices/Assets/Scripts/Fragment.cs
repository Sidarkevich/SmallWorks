using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fragment : MonoBehaviour
{
    [SerializeField] private Image _image;

    public FragmentData Data => _data;

    private FragmentData _data;

    public void Init(FragmentData data)
    {
        _data = data;
        _image.sprite = data.Sprite;
    }

    public void Disappear()
    {
        SelfDestroy();
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
