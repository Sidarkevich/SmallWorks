using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spot : MonoBehaviour
{
    private List<Fragment> _fragments = new List<Fragment>();

    public Fragment GetFirst => _fragments[0];

    public bool CanBeAdded(Fragment applicant)
    {
        bool result = true;

        foreach (var fragment in _fragments)
        {
            foreach (var position in applicant.Data.FragmentPositions)
            {
                result = !(fragment.Data.FragmentPositions.Contains(position));
            }
        }

        return result;
    }

    public void AddFragment(Fragment fragment)
    {
        _fragments.Add(fragment);
        fragment.gameObject.transform.SetParent(transform);
        fragment.gameObject.transform.position = transform.position;
    }

    public void RemoveFragment(Fragment fragment)
    {
        _fragments.Remove(fragment);
    }
}
