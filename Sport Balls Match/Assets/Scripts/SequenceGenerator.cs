using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceGenerator : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;

    private List<Sprite> _list; 

    private void Awake()
    {
        _list = new List<Sprite>(_sprites);
    }

    public List<Sprite> Generate()
    {
        var sequnce = new List<Sprite>();
        Shuffle(_list);
            
        for (int i = 0; i < 3; i++)
        {
            sequnce.Add(_list[i]);
        }

        return sequnce;
    }

    private void Shuffle(List<Sprite> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Sprite value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
