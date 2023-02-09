using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchDamage : GameManager, IWeapons
{

    [SerializeField] private float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DamageAble") && collision.gameObject.layer != enemyLayer)
        {
            collision.gameObject.GetComponent<IWeaponVisitPlayer>().Visit(this, damage);
        }
    }
}
