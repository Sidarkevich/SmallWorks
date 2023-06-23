using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedScaler : MonoBehaviour
{
    public static float SpeedCorrection = 1;

    [SerializeField] private float _scaleFactor;
    [SerializeField] private float _scaleDuration;

    public void StopScaling()
    {
        StopAllCoroutines();
        SpeedCorrection = 1;
    }

    public void Scale(float sign)
    {
        SpeedCorrection = _scaleFactor * sign;
    }

    public void CancelScale()
    {
        StartCoroutine(ScaleCoroutine());
    }

    private IEnumerator ScaleCoroutine()
    {
        yield return new WaitForSeconds(_scaleDuration);

        SpeedCorrection = 1;
    }
}
