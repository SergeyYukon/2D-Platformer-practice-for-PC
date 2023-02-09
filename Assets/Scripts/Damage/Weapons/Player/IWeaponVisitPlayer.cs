
public interface IWeaponVisitPlayer : IWeaponVisit
{
    void Visit(EnemyTouchDamage weapon, float damage);

    void Visit(EnemyKickAttack weapon, float damage);
}
