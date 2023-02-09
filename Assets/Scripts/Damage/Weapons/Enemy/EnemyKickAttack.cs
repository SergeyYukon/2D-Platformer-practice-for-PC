using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKickAttack : GameManager, IWeapons
{
    [SerializeField] private float damage;
    [SerializeField] private float pushPower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamageAble") && collision.gameObject.layer != enemyLayer)
        {
            collision.gameObject.GetComponent<IWeaponVisitPlayer>().Visit(this, damage);
        }

        if (!collision.gameObject.CompareTag("Background") && collision.gameObject.layer != enemyLayer)
        {
            Vector2 direction = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((direction.normalized) * pushPower, ForceMode2D.Impulse);
        }
    }
}
