using UnityEngine;

public class WaterBall : MonoBehaviour
{
    [SerializeField] private float power;
    private Vector2 startPosition;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WaterBall"))
        {
            Vector2 direction = transform.position - collision.transform.position;
            rb.AddForce(direction.normalized * power, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wind")) 
            transform.position = startPosition;
    }
}
