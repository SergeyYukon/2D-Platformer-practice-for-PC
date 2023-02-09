using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject boom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash"))
        {
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
