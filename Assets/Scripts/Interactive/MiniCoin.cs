using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCoin : GameManager
{
    [SerializeField] private int costCoin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            collision.gameObject.GetComponent<CoinsCounter>().GetCoins(costCoin);
            Destroy(gameObject);
        }
    }
}
