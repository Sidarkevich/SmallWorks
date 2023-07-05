using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fragment : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Animation _animation;

    public FragmentData Data => _data;

    private FragmentData _data;

    public void Init(FragmentData data)
    {
        _data = data;
        _image.sprite = data.Sprite;
    }

    public void Disappear()
    {
        _animation.Play("DisappearAnimation");
    }

    public void Appear()
    {
        _animation.Play("AppearAnimation");
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        Appear();
    }
}
