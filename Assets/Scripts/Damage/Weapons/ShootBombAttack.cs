using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBombAttack : GameManager, IWeapons
{
    [SerializeField] private float damage;
    private PointEffector2D pointEffector;
    private CircleCollider2D coll;

    private void Awake()
    {
        pointEffector = GetComponent<PointEffector2D>();
        coll = GetComponent<CircleCollider2D>();
    }

    void Start()
    {
        Destroy(coll, 0.2f);
        Destroy(pointEffector, 0.5f);
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamageAble"))
        {
            collision.gameObject.GetComponent<IWeaponVisit>().Visit(this, damage);
        }
    }
}
