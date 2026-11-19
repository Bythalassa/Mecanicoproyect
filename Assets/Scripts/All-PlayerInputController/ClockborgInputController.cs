/*
    - [ ] y.Y
*/


using System;
using UnityEngine;


public class ClockborgInputController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 8f;
    public float normaljumpForce = 5f;
    public float PunchjumpForce = 9f;

    [Header("Ground Check")]
    public bool IsOnLand;
    public float MoveInput;


    private Rigidbody2D rb;

    public static event Action<bool> OnLand;
    public static event Action OnSpin;
    public static event Action OnHit;
    public static event Action OnDisableJump;
    // public static event Action OnDeath;

    //Enum
 
    
    /*crear el enum de estados aqui
     cocinando*/

    private void OnEnable()
    {
        InputClockborgController.OnMovement += Move;
        InputClockborgController.OnCBShortJump += Jump;
        InputClockborgController.OnCBPunchImpulse += PunchImpulse;
        InputClockborgController.OnCBSpin += Spin;

        MoveInput = InputClockborgController.GetActualWalkDir().x;
    }

    //controla la desubscripción de eventos cuando el objeto se desactiva
    // hacerlo para todas los eventos

    private void OnDisable()
    {
        InputClockborgController.OnMovement -= Move;
        InputClockborgController.OnCBShortJump -= Jump;
        InputClockborgController.OnCBPunchImpulse -= PunchImpulse;
        InputClockborgController.OnCBSpin -= Spin;

        MoveInput = InputClockborgController.GetActualWalkDir().x;
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
        if (!IsOnLand) return;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * normaljumpForce, ForceMode2D.Impulse);
    }

    private void PunchImpulse()
    {
        if (!IsOnLand) return;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * PunchjumpForce, ForceMode2D.Impulse);
    }

    private void Spin()
    {
        OnSpin?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null) 
        {
            //->a 1 hit muera 
            //->b
            //->c
            OnHit?.Invoke();
            //onhit2 (ondestroy)
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnLand = true;
            OnLand?.Invoke(true);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnLand = false;
            OnLand?.Invoke(false);
        }
    }
}


