using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchPush : GameManager, IWeapons
{
    [SerializeField] private float pushPower;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DamageAble") && collision.gameObject.layer != enemyLayer)
        {
            Vector2 direction = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((direction.normalized) * pushPower, ForceMode2D.Impulse);
        }
    }
}
