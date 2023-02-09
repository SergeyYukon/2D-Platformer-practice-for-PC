using UnityEngine;


public class CartMovement : GameManager, IMovement
{
    [SerializeField] private AnimationCurve speedCurve;
    private PolygonCollider2D coll;
    private BoxCollider2D collTrigger;
    private Rigidbody2D rb;
    private bool isRolling;
    private bool isDeActivate;

    private void Awake()
    {
        coll = GetComponent<PolygonCollider2D>();
        collTrigger = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalDirection)
    {
        Movement(horizontalDirection);
    }

    public void Jump()
    {
        isRolling = false;
        EventController.PlayerMove();
    }

    public void Animations()
    {

    }

    private void Movement(float horizontalDirection)
    {
        rb.velocity = new Vector2(speedCurve.Evaluate(horizontalDirection), rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CartDeActivate")) isDeActivate = true;

        if (!isDeActivate)
        {
            if (collision.gameObject.layer == playerLayer)
            {
                EventController.CartMove();
                collision.gameObject.GetComponent<Animator>().SetBool("isRunning", false);
                collision.gameObject.GetComponent<Animator>().SetInteger("jumpState", 0);
                isRolling = true;
            }
        }
        else
        {
            isRolling = false;
            EventController.PlayerMove();
        }
    
        if (collision.CompareTag("Water"))
        {
            coll.usedByEffector = false;
            collTrigger.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            if (isRolling) 
            { 
                collision.transform.position = Vector2.MoveTowards(collision.transform.position, transform.position, 0.05f);
                collision.transform.localScale = new Vector2(1, 1);
                EventController.RightDirection();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            EventController.PlayerMove();
        }
    }
}
