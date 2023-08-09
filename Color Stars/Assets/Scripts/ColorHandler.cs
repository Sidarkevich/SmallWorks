using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    [SerializeField] private List<Sprite> _allColors;

    private List<Sprite> _colors;

    public Sprite GetAnotherRandom(Sprite sprite)
    {
        _colors.Remove(sprite);
        var result = _colors[Random.Range(0, _colors.Count)];
        _colors.Add(sprite);

        return result;
    }

    public Sprite GetRandom()
    {
        return _colors[Random.Range(0, _colors.Count)];
    }

    private void Awake()
    {
        _colors = new List<Sprite>(_allColors);
    }
}
