using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerHitBox : MonoBehaviour, IWeaponVisitPlayer
{
    [SerializeField] private float swordResistance;
    [SerializeField] private float shootResistance;
    private Health health;

    private void Awake()
    {
        health = gameObject.GetComponent<Health>();
    }

    public void Visit(EnemyTouchDamage weapon, float damage)
    {
        float damageCounter = damage - swordResistance;
        health.GetDamage(damageCounter);
    }

    public void Visit(ShootBombAttack weapon, float damage)
    {
        float damageCounter = damage - shootResistance;
        health.GetDamage(damageCounter);
    }

    public void Visit(EnemyKickAttack weapon, float damage)
    {
        float damageCounter = damage - swordResistance;
        health.GetDamage(damageCounter);
    }
}
