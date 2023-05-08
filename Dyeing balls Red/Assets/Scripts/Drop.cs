using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Drop : MonoBehaviour
{
    [SerializeField] private float _fallSpeed;

    public abstract void UseEffect(Ball ball);

    private void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime*_fallSpeed);
    }
}