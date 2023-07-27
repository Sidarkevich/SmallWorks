using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceKeeper : MonoBehaviour
{
    [SerializeField] private List<Spot> _spots;
    [SerializeField] private SequenceGenerator _generator;
    [SerializeField] private float _sameChance;

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

        if (Random.Range(0f, 1f) < _sameChance)
        {
            _answerSequence = new List<Sprite>(_questionSequence);
            _generator.Shuffle(_answerSequence);
        }
        else
        {
            _answerSequence = _generator.Generate();
        }
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
