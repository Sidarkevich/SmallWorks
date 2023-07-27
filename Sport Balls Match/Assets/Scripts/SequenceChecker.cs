using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SequenceChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent _correctAnswerEvent;
    [SerializeField] private UnityEvent _incorrectAnswerEvent;

    [SerializeField] private SequenceKeeper _keeper;

    public void CheckAnswer(bool answer)
    {
        bool result = true;

        foreach (var element in _keeper.QuestionSequence)
        {
            if (!_keeper.AnswerSequence.Contains(element))
            {
                result = false;
            }
        }

        if (answer == result)
        {
            _correctAnswerEvent?.Invoke();
        }
        else
        {
            _incorrectAnswerEvent?.Invoke();
        }
    }
}
