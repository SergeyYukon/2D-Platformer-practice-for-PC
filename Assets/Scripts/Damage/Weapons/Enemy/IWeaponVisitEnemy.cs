using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponVisitEnemy : IWeaponVisit
{
    void Visit(SwordAttack weapon, float damage);

    void Visit(ShootAttack weapon, float damage);
}
