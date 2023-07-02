using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private ScoreHandler _score;

    public bool Check(Vector3 point)
    {
        RaycastHit2D hit = Physics2D.CircleCast(point, 0.1f, Vector3.zero);

        if (hit)
        {
            var zone = hit.transform.GetComponent<HitZone>();

            if (zone)
            {
                _score.IncreaseScore(zone.HitValue);
                zone.Board.Disappear();
                
                return true;
            }
        }

        return false;
    }
}
