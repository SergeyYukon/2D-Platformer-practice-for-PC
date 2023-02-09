using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : GameManager
{
    [SerializeField] private float speed;
    [SerializeField] private Transform rightStopTransform;
    [SerializeField] private Transform leftStopTransform;
    private bool leftDirection;

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(playerLayer))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(playerLayer))
        {
            collision.transform.SetParent(null);
        }
    }

    private void Movement()
    {
        float distanceRight = Vector2.Distance(transform.position, rightStopTransform.position);
        float distanceLeft = Vector2.Distance(transform.position, leftStopTransform.position);

        if (distanceRight < 0.1f) leftDirection = true;
        else if (distanceLeft < 0.1f) leftDirection = false;

        if (!leftDirection) transform.position = Vector2.MoveTowards(transform.position, rightStopTransform.position, speed * Time.fixedDeltaTime);
        else transform.position = Vector2.MoveTowards(transform.position, leftStopTransform.position, speed * Time.fixedDeltaTime);
    }
}
