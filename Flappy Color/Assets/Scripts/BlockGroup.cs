using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGroup : MonoBehaviour
{
    [SerializeField] private List<Block> _blocks;
    [SerializeField] private List<int> _colors;

    private void OnEnable()
    {
        ShuffleColors();
        
        for (int i = 0; i < _colors.Count; i++)
        {
            _blocks[i].Color.ChangeColor(_colors[i]);
        }
    }

    private void ShuffleColors()
    {
        int n = _colors.Count;  
        
        while (n > 1)
        {  
            n--;  
            int k = Random.Range(0, n + 1);  
            int value = _colors[k];  
            _colors[k] = _colors[n];  
            _colors[n] = value;  
        } 
    }
}
