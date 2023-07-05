using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Spot : MonoBehaviour
{
    public UnityEvent<Spot> FullOfFragmentsEvent;

    private List<Fragment> _fragments = new List<Fragment>();
    private int _totalScore;

    public Fragment GetFirst => _fragments[0];
    public int TotalScore => _totalScore;

    public bool CanBeAdded(Fragment applicant)
    {
        bool result = true;

        foreach (var fragment in _fragments)
        {
            foreach (var position in applicant.Data.FragmentPositions)
            {
                if (fragment.Data.FragmentPositions.Contains(position))
                {
                    result = false;
                }
            }
        }

        return result;
    }

    public void AddFragment(Fragment fragment)
    {
        _fragments.Add(fragment);
        fragment.gameObject.transform.SetParent(transform);
        fragment.gameObject.transform.position = transform.position;

        _totalScore += fragment.Data.ScoreValue;

        if (_totalScore >= 6)
        {
            FullOfFragmentsEvent?.Invoke(this);
        }
    }

    public void RemoveFragment(Fragment fragment)
    {
        _fragments.Remove(fragment);
    }

    public void Clear()
    {
        foreach (var fragment in _fragments)
        {
            fragment.Disappear();
        }

        _fragments.Clear();
        _totalScore = 0;
    }
}
