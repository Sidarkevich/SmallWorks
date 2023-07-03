using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _maxForce;
    
    public void Shoot(Vector2 mousePos)
    {
        var direction = new Vector2(transform.position.x, transform.position.y) - mousePos;

        _rb.simulated = true;
        _rb.AddForce(direction * 4.1f, ForceMode2D.Impulse);
    }

    private void Update()
    {
        Vector2 moveDirection = _rb.velocity;
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
