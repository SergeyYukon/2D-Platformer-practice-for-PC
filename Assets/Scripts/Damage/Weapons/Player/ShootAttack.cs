using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : GameManager, IWeapons
{
    [SerializeField] private float damage;
    [SerializeField] private float pushPower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamageAble") && collision.gameObject.layer != playerLayer)
        {
            collision.gameObject.GetComponent<IWeaponVisitEnemy>().Visit(this, damage);

            Vector2 direction = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((direction.normalized) * pushPower, ForceMode2D.Impulse);

            Destroy(gameObject);
        }
        else if (!collision.gameObject.CompareTag("Background")) Destroy(gameObject);
    }
}
