using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private GameObject boom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ActivateBoom"))
        {
            Boom();
        }
    }

    public void Boom()
    {
        Instantiate(boom, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
