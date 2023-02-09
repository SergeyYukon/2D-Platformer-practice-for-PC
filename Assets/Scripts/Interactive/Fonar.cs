using UnityEngine;

public class Fonar : MonoBehaviour
{
    [SerializeField] private float power;
    private Animator anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Weapon"))
        {
            anim.SetTrigger("Touch");
            Vector2 direction = transform.position - collision.transform.position;
            rb.AddForce(direction.normalized * power, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            anim.SetTrigger("Touch");
        }
    }

    public void TurnOn()
    {
        anim.SetBool("TurnOn", true);
    }

    public void TurnOff()
    {
        anim.SetBool("TurnOn", false);
    }
}
