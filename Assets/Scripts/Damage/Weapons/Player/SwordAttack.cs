using UnityEngine;

public class SwordAttack : GameManager, IWeapons
{
    [SerializeField] private float damage;
    [SerializeField] private float pushPower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamageAble") && collision.gameObject.layer != playerLayer)
        {
            collision.gameObject.GetComponent<IWeaponVisitEnemy>().Visit(this, damage);
        }
        
        if (!collision.gameObject.CompareTag("Background") && collision.gameObject.layer != playerLayer)
        {
            Vector2 direction = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((direction.normalized) * pushPower, ForceMode2D.Impulse);
        }
    }
}
