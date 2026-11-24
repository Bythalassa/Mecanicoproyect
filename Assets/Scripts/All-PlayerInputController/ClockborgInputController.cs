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
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;      


    [Header("Jump Cut")]
    [SerializeField] private float jumpCutMultiplier = 0.1f;

    [Header("Spin")]
    [SerializeField] private int SpinForce = 20;
    private bool airPunchUsed;

    private bool canSpin;

    private Rigidbody2D rb;

    public static event Action<bool> OnLand;
    public static event Action<bool> OnSpin;
    public static event Action OnHit;
    public static event Action OnCallBirdbot;
    // public static event Action OnDeath;

    ClockborgAnimatorController ClockborgAnimatorController;

    private void OnEnable()
    {
        InputClockborgController.OnMovement += Move;
        InputClockborgController.OnCBShortJump += Jump;
        InputClockborgController.OnCBPunchImpulse += PunchImpulse;
        InputClockborgController.OnCBSpin += Spin;
        InputClockborgController.OnCallBirdbot += Call;
        InputClockborgController.OnCBSpinFinish += StopSpinAnimation;


        MoveInput = InputClockborgController.GetActualWalkDir().x;
    }


    private void OnDisable()
    {
        InputClockborgController.OnMovement -= Move;
        InputClockborgController.OnCBShortJump -= Jump;
        InputClockborgController.OnCBPunchImpulse -= PunchImpulse;
        InputClockborgController.OnCBSpin -= Spin;
        InputClockborgController.OnCBSpinFinish -= StopSpinAnimation;

        MoveInput = InputClockborgController.GetActualWalkDir().x;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ClockborgAnimatorController = GetComponent<ClockborgAnimatorController>();

    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(MoveInput * speed, rb.linearVelocity.y);

        if ( canSpin )
            rb.AddForce(new Vector2(MoveInput * SpinForce, 0f), ForceMode2D.Force);

        bool grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        /*Collider2D Physics2D.OverlapCircle(Vector2 punto, float radio, LayerMask capas);*/

        if (grounded != IsOnLand)
        {
            IsOnLand = grounded;

            if (grounded)
                airPunchUsed = false;

            OnLand?.Invoke(grounded);
        }

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

        if (rb.linearVelocity.y <= 0 || !IsOnLand)
        {
            rb.AddForce(Vector2.down * rb.linearVelocity.y * (1 - jumpCutMultiplier), ForceMode2D.Impulse);
        }
    }

    private void PunchImpulse()
    {
        if (!IsOnLand && airPunchUsed) return;
        if (!IsOnLand) airPunchUsed = true;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * PunchjumpForce, ForceMode2D.Impulse);

    }

    private void Spin()
    {
        canSpin = true;
        OnSpin?.Invoke(true);
    }

    private void StopSpinAnimation()
    {
        canSpin = false;
        OnSpin?.Invoke(false);
    }

    private void Call()
    {
        OnCallBirdbot?.Invoke();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null) 
        {
            //->b
            //->c
            OnHit?.Invoke();
            //onhit2 (ondestroy) okay.-.
        }
    }

}


