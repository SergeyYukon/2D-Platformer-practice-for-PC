using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : GameManager
{
    [SerializeField] private int costHeal;
    private Animator anim;
    private const float destroyTime = 0.1f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            collision.GetComponent<Health>().GetHeal(costHeal);
            anim.SetTrigger("_get");
            Destroy(gameObject, destroyTime);
        }
    }
}
