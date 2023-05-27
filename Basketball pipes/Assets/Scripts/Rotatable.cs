using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    public void RotateAroundZ(int degrees)
    {
        transform.Rotate(Vector3.forward * degrees, Space.World);
    }
}
