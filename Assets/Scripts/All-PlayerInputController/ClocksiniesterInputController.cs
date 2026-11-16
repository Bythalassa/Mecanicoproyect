/*
    - [ ] y.Y*/

using System;
using UnityEngine;


public class ClocksiniesterInputController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 8f;
    public float jumpForce = 7f;

    [Header("Ground Check")]
    public bool isGrounded;
    public float MoveInput;

    [Header("Combat")]
    public float AttackRadius;

    private Rigidbody2D rb;


    public static event Action OnCSHit;
    public static event Action<bool> OnGround;

private void OnEnable()
    {
        InputClocksiniesterController.OnWalkUpsidedown += Move;
        InputClocksiniesterController.OnCSShortJump += Jump;
        InputClocksiniesterController.OnPunchImpulse += PunchImpulse;
        InputClocksiniesterController.OnCSSpin += Spin;
        InputClocksiniesterController.OnAttack += Attack;
        InputClocksiniesterController.OnSpeedGear += SpeedGear;

    }

    //controla la desubscripción de eventos cuando el objeto se desactiva
    // hacerlo para todas los eventos

    private void OnDisable()
    {
        InputClocksiniesterController.OnWalkUpsidedown -= Move;
        InputClocksiniesterController.OnCSShortJump -= Jump;
        InputClocksiniesterController.OnPunchImpulse -= PunchImpulse;
        InputClocksiniesterController.OnCSSpin -= Spin;
        InputClocksiniesterController.OnAttack -= Attack;
        InputClocksiniesterController.OnSpeedGear -= SpeedGear;  
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(MoveInput * speed, rb.linearVelocity.y);
    }

    private void Move(Vector2 input)
    {
        MoveInput = input.x;
    }

    private void Jump()
    {
        jumpForce = 7f;
        if (!isGrounded) return;

        Debug.Log("salte");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void PunchImpulse()
    {
        jumpForce = 10f;
    }

    private void Spin()
    {
        speed = 9f;
    }

    private void Attack()
    {

        Collider2D[] Coll = Physics2D.OverlapCircleAll(transform.position, AttackRadius);

        foreach (Collider2D coll in Coll)
        {
            if (coll.gameObject.GetComponent<IDamageable>() != null)
            {
                coll.gameObject.GetComponent<IDamageable>().TakeDamage();
            }
        }
    }

    private void SpeedGear()
    {

        Collider2D[] Coll = Physics2D.OverlapCircleAll(transform.position, AttackRadius);

        foreach (Collider2D coll in Coll)
        {
            if (coll.gameObject.GetComponent<ISlowdownable>() != null)
            {
                coll.gameObject.GetComponent<ISlowdownable>().Slowdown();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null)
        {
            //->a
            //->b
            //->c
            OnCSHit?.Invoke();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            OnGround?.Invoke(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            OnGround?.Invoke(false);
        }
    }
}
