using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Barrel))]
public class BombHitBox : MonoBehaviour, IWeaponVisit, IWeaponVisitEnemy, IWeaponVisitPlayer
{
    private Barrel barrel;

    private void Awake()
    {
        barrel = gameObject.GetComponent<Barrel>();
    }

    public void Visit(ShootBombAttack weapon, float damage)
    {
        barrel.Boom();
    }

    public void Visit(SwordAttack weapon, float damage)
    {
        barrel.Boom();
    }

    public void Visit(ShootAttack weapon, float damage)
    {
        barrel.Boom();
    }

    public void Visit(EnemyTouchDamage weapon, float damage)
    {
        barrel.Boom();
    }

    public void Visit(EnemyKickAttack weapon, float damage)
    {
        barrel.Boom();
    }
}
