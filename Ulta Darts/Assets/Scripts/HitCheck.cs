using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private ScoreHandler _score;

    public bool Check(Vector3 point)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(point, 0.001f, Vector3.one);

        if (hits.Length > 0)
        {
            var maxHit = 0;
            HitZone resultZone = null;

            foreach (var hit in hits)
            {
                var zone = hit.transform.GetComponent<HitZone>();

                if (zone)
                {
                    if (zone.HitValue > maxHit)
                    {
                        resultZone = zone;
                        maxHit = zone.HitValue;
                    }
                }
            }

            if (resultZone)
            {
                _score.IncreaseScore(resultZone.HitValue);
                resultZone.Board.Disappear();

                return true;
            }
        }

        _score.Loss();
        return false;
    }
}
