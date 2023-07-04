using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spot : MonoBehaviour
{
    [SerializeField] private List<Spot> _neighbors;

    private List<Fragment> _fragments = new List<Fragment>();
    private int _totalScore;

    public Fragment GetFirst => _fragments[0];

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

        }
    }

    public void RemoveFragment(Fragment fragment)
    {
        _fragments.Remove(fragment);
    }
}
