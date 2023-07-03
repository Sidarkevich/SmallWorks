using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    
    public void Shoot(Vector2 mousePos)
    {
        Debug.Log("Shoot!");
        var direction = new Vector2(transform.position.x, transform.position.y) - mousePos;
        var forceValue = direction.magnitude;

        _rb.velocity = (direction * forceValue);
    }
}
