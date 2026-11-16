/*
    - [ ] y.Y
*/


using System;
using UnityEngine;


public class ClockborgInputController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 8f;
    public float jumpForce = 5f;

    [Header("Ground Check")]
    public bool isGrounded;
    public float MoveInput;

    private Rigidbody2D rb;


    public static event Action OnHit;
    public static event Action<bool> OnGround;
    public static event Action OnStepBack;
    public static event Action OnSpin;
    public static event Action IsCalled;

    //Enum
    /*crear el enum de estados aqui*/

    private void OnEnable()
    {
        InputClockborgController.OnMove += Move;
        InputClockborgController.OnCBShortJump += Jump;
        InputClockborgController.OnStepBack += StepBack;
        InputClockborgController.OnCBSpin += Spin;
        InputClockborgController.OnCallBirdbot += CallBirdbot;
    }


    //controla la desubscripción de eventos cuando el objeto se desactiva
    // hacerlo para todas los eventos

    private void OnDisable()
    {
        InputClockborgController.OnMove -= Move;
        InputClockborgController.OnCBShortJump -= Jump;
        InputClockborgController.OnStepBack -= StepBack;
        InputClockborgController.OnCBSpin -= Spin;
        InputClockborgController.OnCallBirdbot -= CallBirdbot;
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
        speed = 8f;
    }

    private void StepBack()
    {
         speed = 6f;
         OnStepBack?.Invoke();
    }

    private void Jump()
    {
        if (!isGrounded) return;

        Debug.Log("salte");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Spin()
    {
        speed = 10f;
        OnSpin?.Invoke();
    }

    private void CallBirdbot()
    {
        IsCalled?.Invoke();
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
