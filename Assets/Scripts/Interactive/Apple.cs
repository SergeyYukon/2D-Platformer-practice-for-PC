using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : GameManager
{
    [SerializeField] private int costApple;
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
            collision.GetComponent<ApplesCounter>().GetApples(costApple);
            anim.SetTrigger("_get");
            Destroy(gameObject, destroyTime);
        }
    }
}
