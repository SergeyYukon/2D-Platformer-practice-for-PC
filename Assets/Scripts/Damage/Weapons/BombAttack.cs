using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : GameManager
{
    [SerializeField] private GameObject boom;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Background"))
        {
            Instantiate(boom, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
