using UnityEngine;
using System.Collections;
using Cinemachine;

[RequireComponent(typeof(PlayerAttack), typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : GameManager, IMovement, IDamageAble
{
    [Header("MoveSettings")]
    [SerializeField] private float maxAcceleration;
    [SerializeField] private float maxAirAcceleration;
   // [SerializeField] private float maxSpeed;
    [SerializeField] private AnimationCurve speedCurve;
    [Header("JumpSettings")]
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundPointTransform;
    [SerializeField] private float radiusCircleJump;
    [SerializeField] private LayerMask ground;
    [Header("Others")]
    [SerializeField] private CinemachineVirtualCamera vcamLeft;
    private const int vcamLookRight = 0;
    private const int vcamLookLeft = 2;
    private const int attackEnd = 0;
    private const int attack1 = 1;
    private const int attack2 = 2;
    private const int attack3 = 3;
    private int attackState;
    private float stopAttackTime;
    private bool isGrounded = true;
    private bool isRun;
    private bool isJump;
    private bool isStopAttack, isStopAttack2, isStopAttack3;
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerAttack swordAttack;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        swordAttack = GetComponent<PlayerAttack>();
        vcamLeft = vcamLeft.GetComponent<CinemachineVirtualCamera>();
        EventController.Fire1ButtonPressedEvent += Attack;
        EventController.CutSceneEvent += CutScene;
    }
    private void Update()
    {
        CheckGround();
    }

    public void Move(float horizontalDirection)
    {     
        Movement(horizontalDirection);          
        LookDirection(horizontalDirection);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJump = true;
        }
    }

    public void Animations()
    {
        if (isGrounded)
            {
                if (isRun) anim.SetBool("isRunning", true);
                else anim.SetBool("isRunning", false);

                anim.SetInteger("jumpState", 0);
                if (isJump)
                {
                    anim.SetInteger("jumpState", 1);
                    isJump = false;
                }
            }         
        else if (!isGrounded)           
        {             
            isRun = false;             
            anim.SetInteger("jumpState", 2);           
        }
    }

    public void GetDamage()
    {
        anim.SetTrigger("_getDamage");
    }

    public void Death()
    {
        const float lateDeathTime = 1f;
        anim.SetTrigger("_death");
        rb.constraints = RigidbodyConstraints2D.None;
        isPlayerDeath = true;
        EventController.PlayerDeath(lateDeathTime);
    }

    private void CutScene()
    {
        rb.velocity = Vector2.zero;
        anim.SetBool("isRunning", false);
        anim.SetInteger("jumpState", 0);
    }

    private void ContinueAttack1() //запуск в конце анимации Attack1
    {
        if(attackState == attack1)
        {
            ResetAttackState();
        }
        else if(attackState == attack2)
        {
            stopAttackTime = 0.23f; // длина анимации Attack2
            isStopAttack2 = true;
            StartCoroutine(AttackTime(stopAttackTime, attackState));
        }
    }

    private void ContinueAttack2() //запуск в конце анимации Attack2
    {
        if (attackState == attack2)
        {
            ResetAttackState();
        }
        else if(attackState == attack3)
        {
            stopAttackTime = 0.36f; // длина анимации Attack3
            isStopAttack3 = true;
            StartCoroutine(AttackTime(stopAttackTime, attackState));
        }
    }

    private void ContinueAttack3() //запуск в конце анимации Attack3
    {
        ResetAttackState();
    }

    private void ResetAttackState()
    {
        attackState = attackEnd;
        anim.SetInteger("attackState", attackEnd);
        isStopAttack = false;
        isStopAttack2 = false;
        isStopAttack3 = false;
    }

    private void Attack()
    {
        if (!isStopAttack2 && !isStopAttack3)
        {
            if (!isStopAttack)
            {
                attackState = attack1;
                stopAttackTime = 0.30f; // длина анимации Attack1
                isStopAttack = true;
                StartCoroutine(AttackTime(stopAttackTime, attackState));
            }
            else attackState = attack2;
        }
        else attackState = attack3;
    }

    private IEnumerator AttackTime(float stopAttackTime, int attackState)
    {
        anim.SetInteger("attackState", attackState);
        swordAttack.Attacking(stopAttackTime);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(stopAttackTime);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundPointTransform.position, radiusCircleJump, ground);
    }

    private void Movement(float horizontalDirection)
    {
        if (Mathf.Abs(horizontalDirection) > 0)
        {
            float acceleration = isGrounded ? maxAcceleration : maxAirAcceleration;
           // Vector2 desiredVelocity = new Vector2(horizontalDirection, 0f) * Mathf.Max(maxSpeed - 0.5f, 0f);                       
            Vector2 desiredVelocity = new Vector2(speedCurve.Evaluate(horizontalDirection), 0f);
            Vector2 velocity = rb.velocity;
            velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, acceleration * Time.deltaTime);
            rb.velocity = velocity;
            isRun = true;
        }
        else
        {
            isRun = false;
        }

    }

    private void LookDirection(float horizontalDirection)
    {
        if (horizontalDirection > 0)
        {
            transform.localScale = new Vector2(1, 1);
            vcamLeft.Priority = vcamLookRight;
            EventController.RightDirection();
        }
        else if (horizontalDirection < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            vcamLeft.Priority = vcamLookLeft;
            EventController.LeftDirection();
        }
    }
}
