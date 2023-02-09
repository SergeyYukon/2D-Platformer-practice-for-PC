using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : GameManager
{
    [SerializeField] private int costCoin;
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
            collision.GetComponent<CoinsCounter>().GetCoins(costCoin);
            anim.SetTrigger("_getCoin");
            Destroy(gameObject, destroyTime);
        }
    }
}
