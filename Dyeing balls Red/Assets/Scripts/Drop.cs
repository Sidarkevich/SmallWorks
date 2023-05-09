using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Drop : MonoBehaviour
{
    [SerializeField] private Vector2 _speedExtremums;

    private float _fallSpeed;

    public abstract void UseEffect(Ball ball);

    private void OnEnable()
    {
        _fallSpeed = UnityEngine.Random.Range(_speedExtremums.x, _speedExtremums.y);
    }

    private void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime*_fallSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();

        if (ball)
        {
            UseEffect(ball);
        }

        Destroy(gameObject);
    }
}