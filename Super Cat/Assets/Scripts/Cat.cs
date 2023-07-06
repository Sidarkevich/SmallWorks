using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    public void Jump()
    {
        _rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }
}
