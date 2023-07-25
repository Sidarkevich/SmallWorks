using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceKeeper : MonoBehaviour
{
    [SerializeField] private List<Spot> _spots;


    private List<Sprite> _sequence;

    public List<Sprite> Sequence => _sequence;

    public void SetSequence(List<Sprite> sequence)
    {
        _sequence = sequence;

        for (int i = 0; i < sequence.Count; i++)
        {
            _spots[i].Setup(sequence[i]);
        }
    }
}
