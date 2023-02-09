using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyHitBox : MonoBehaviour, IWeaponVisitEnemy
{
    [SerializeField] private float swordResistance;
    [SerializeField] private float shootResistance;
    private Health health;

    private void Awake()
    {
       health = gameObject.GetComponent<Health>();  
    }

    public void Visit(SwordAttack weapon, float damage)
    {
        float damageCounter = damage - swordResistance;
        health.GetDamage(damageCounter);
    }

    public void Visit(ShootAttack weapon, float damage)
    {
        float damageCounter = damage - shootResistance;
        health.GetDamage(damageCounter);
    }

    public void Visit(ShootBombAttack weapon, float damage)
    {
        float damageCounter = damage - shootResistance;
        health.GetDamage(damageCounter);
    }
}
