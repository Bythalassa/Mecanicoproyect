using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 8f;
    public float jumpForce = 5f;

    [Header("Ground Check")]
    public bool isGrounded;
    public float MoveInput;

    [Header("Combat")]
    public float AttackRadius;

    private Rigidbody2D rb;


    public static event Action OnHit;
    public static event Action<bool> OnGround;
    //OnHit?.Invoke();

    private void OnEnable()
    {
        InputManagerController.OnMove += Move;
        InputManagerController.OnJump += Jump;
        InputManagerController.OnAttack += Attack;
    }



    private void OnDisable()
    {
        InputManagerController.OnMove -= Move;
        InputManagerController.OnJump -= Jump;
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
        if (!isGrounded) return;


        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null)
        {
            //->a
            //->b
            //->c
            OnHit?.Invoke();
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
