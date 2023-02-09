using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMushroom : MonoBehaviour, IDamageAble
{
    [SerializeField] private float speed, stopTime;
    [SerializeField] private float afterAttackTime;
    [SerializeField] private Transform barTransform;
    [Header("GroundSettings")]
    [SerializeField] private Transform groundPointTransform;
    [SerializeField] private float radiusCircleJump;
    [SerializeField] private LayerMask ground;
    private Animator anim;
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private Attack attack;
    private const int idleState = 0;
    private const int walkState = 1;
    private const int revertState = 2;
    private const int attackState = 3;
    private int currentState;
    private float currentStopTime;
    private float waitTime;
    private bool leftDirection;
    private bool isDeath;
    private bool isBack;
    private bool isStopAttack;
    private bool isBehavior;
    private bool isGrounded;
    private bool isFreezed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        attack = GetComponent<Attack>();
    }

    private void Start()
    {
        currentState = walkState;
        currentStopTime = 0;
    }

    private void Update()
    {
        CheckGround();

        if (!isDeath)
        {
            if (isGrounded)
            {
                switch (currentState)
                {
                    case idleState:
                        Idle();
                        break;
                    case revertState:
                        Revert();
                        break;
                    case attackState:
                        Attack();
                        break;
                }
            }
            else Idle();
        }

        anim.SetFloat("Velocity", rb.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        if (!isDeath)
        {
            if (isGrounded)
            {
                switch (currentState)     
                {         
                    case walkState:              
                        Move();               
                        break;      
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper")) currentState = idleState;
        if (collision.CompareTag("DeathTrigger"))
        {
            EventController.EnemyDeath();
            Destroy(gameObject);
        }
    }

    public void GetDamage()
    {
        anim.SetTrigger("_getDamage");
        if (isBack) 
        {
            StartCoroutine(GetDamageWait());
        }
    }

    public void Death()
    {
        StopCoroutine("AttackTime");
        attack.StopCoroutine("StartAttack");
        if (!isFreezed)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        }
        anim.SetTrigger("_death");
        coll.enabled = false;
        isDeath = true;
        EventController.EnemyDeath();
    }

    public void OnBehavior()
    {
        currentState = attackState;
        isBehavior = true;
    }

    public void OffBehavior()
    {
        currentState = walkState;
        isBehavior = false;
    }

    public void HeIsBack()
    {
        isBack = true;
    }

    public void HeIsNotBack()
    {
        isBack = false;
    }

    private void Attack()
    {
        if (!isStopAttack)
        {
            StartCoroutine("AttackTime");
        }
    }

    private IEnumerator AttackTime()
    {
        isStopAttack = true;
        currentState = attackState;
        waitTime = 0.6f; //длина анимации
        attack.Attacking(waitTime);
        anim.SetTrigger("_attack");
        rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        isFreezed = true;
        yield return new WaitForSeconds(waitTime);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        isFreezed = false;
        yield return new WaitForSeconds(afterAttackTime);
        isStopAttack = false;
    }

    private IEnumerator GetDamageWait()
    {
        const float wait = 0.1f; // длина анимации
        yield return new WaitForSeconds(wait);
        isBehavior = true;
        currentState = revertState;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundPointTransform.position, radiusCircleJump, ground);
    }

    private void Idle()
    {
        currentStopTime += Time.deltaTime;
        if (currentStopTime >= stopTime)
        {
            currentStopTime = 0;
            currentState = revertState;
        }
    }

    private void Move()
    {
        if(!leftDirection) rb.velocity = Vector2.right * speed;
        else rb.velocity = Vector2.left * speed;
    }

    private void Revert()
    {
        if (!leftDirection)
        {
            transform.localScale = new Vector2(-1, 1);
            barTransform.localScale = new Vector2(-1, 1);
            leftDirection = true;
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
            barTransform.localScale = new Vector2(1, 1);
            leftDirection = false;
        }
        if(!isBehavior) currentState = walkState;
    }
}
