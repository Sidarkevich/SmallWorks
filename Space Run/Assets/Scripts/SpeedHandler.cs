using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    public const float StartSpeed = 2.0f;
    public const float MinSpeed = 1.0f;
    public static float SpeedValue;

    public static void ChangeSpeed(float newValue)
    {
        SpeedValue = Mathf.Max(newValue, SpeedValue);
    }

    public static void ResetSpeed()
    {
        SpeedValue = StartSpeed;
    }
}
