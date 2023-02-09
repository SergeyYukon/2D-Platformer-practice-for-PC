using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalingEnemy : MonoBehaviour, IDamageAble
{
    private PolygonCollider2D coll;
    private Animator anim;

    private void Awake()
    {
        coll = gameObject.GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
    }

    public void GetDamage()
    {
        anim.SetTrigger("_getDamage");
    }

    public void Death()
    {
        anim.SetTrigger("_death");
        coll.enabled = false;
    }
}
