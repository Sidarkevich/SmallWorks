using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceKeeper : MonoBehaviour
{
    [SerializeField] private List<Spot> _spots;
    [SerializeField] private SequenceGenerator _generator;

    private List<Sprite> _questionSequence;
    private List<Sprite> _answerSequence;
    private List<Sprite> _currentSequence;

    public List<Sprite> QuestionSequence => _questionSequence;
    public List<Sprite> AnswerSequence => _answerSequence;

    private void Start()
    {
        SetNewSequences();
    }

    private void SetNewSequences()
    {
        _questionSequence = _generator.Generate();
        _answerSequence = _generator.Generate();
    }

    public void Setup()
    {
        if (_currentSequence == _answerSequence)
        {
            SetNewSequences();
            _currentSequence = _questionSequence;
        }
        else
        {
            _currentSequence = _answerSequence;
        }

        for (int i = 0; i < _currentSequence.Count; i++)
        {
            _spots[i].Setup(_currentSequence[i]);
        }
    }
}
