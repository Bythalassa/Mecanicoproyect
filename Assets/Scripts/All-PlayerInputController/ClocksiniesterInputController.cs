/*
    - [ ] y.Y*/

using System;
using UnityEngine;


public class ClocksiniesterInputController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 8f;
    public float jumpForce = 7f;
    public float punchForce = 19f;

    [Header("Ground Check")]
    public bool isGrounded;
    public float MoveInput;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Spin")]
    [SerializeField] private int SpinForce = 20;
    private bool canSpin;
    private bool airPunchUsed;

    [SerializeField] private float jumpCutMultiplier = 2f;

    private Rigidbody2D rb;

    public static event Action OnCSHit;
    public static event Action<bool> OnGround;
    public static Action<bool> OnCSSpin;

    [Header("Combat")]
    public float AttackRadius;
    [SerializeField] private GameObject balaMetalicaPrefab;
    /*Información que deberia hacerse fetch desde un SO
     -- BulletSpeed

    -- municionActual--; (funcion que verifique si tiene municion), ademas que tenga referencia a una variante que suma municion dentro del script CollectAMMo.
    -- siguienteDisparo = Time.time + tiempoEntreDisparos;
    
    -- sabiendo que el prefab de balametalica tiene un script que configura las siguientes caracteristicas:
    +++ Velocidad
    +++ Danio
    +++ Tiempo Vida

    que es caracteristicas y parametros podria establecer desde el script dispar
    y que se mantiene en el prefab de la bala? 
    
     */

    [SerializeField] private float bulletSpeed = 10f;

    private Vector2 aimDir = Vector2.right;
    private void OnEnable()
    {
        InputClocksiniesterController.OnWalkUpsidedown += Move;
        InputClocksiniesterController.OnCSShortJump += Jump;
        InputClocksiniesterController.OnPunchImpulse += PunchImpulse;
        InputClocksiniesterController.OnCSSpin += Spin;
        InputClocksiniesterController.OnAttack += Attack;
        InputClocksiniesterController.OnSpeedGear += SpeedGear;
        InputClocksiniesterController.OnCSSpinFinish += StopSpinAnimation;
        AimController.OnAim += UpdateAim;

        MoveInput = InputClocksiniesterController.GetActualWalkDir().x;
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
        InputClocksiniesterController.OnCSSpinFinish -= StopSpinAnimation;
        AimController.OnAim -= UpdateAim;


        MoveInput = InputClocksiniesterController.GetActualWalkDir().x;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(MoveInput * speed, rb.linearVelocity.y);

        bool grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        /*Collider2D Physics2D.OverlapCircle(Vector2 punto, float radio, LayerMask capas);*/

        if (grounded != isGrounded)
        {
            isGrounded = grounded;

            if (grounded)
                airPunchUsed = false;

            OnGround?.Invoke(grounded);
        }

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

        if (rb.linearVelocity.y <= 0 || !isGrounded)
        {
            rb.AddForce(Vector2.down * rb.linearVelocity.y * (1 - jumpCutMultiplier), ForceMode2D.Impulse);
        }

    }

    private void PunchImpulse()
    {
        if (!isGrounded && airPunchUsed) return;
        if (!isGrounded) airPunchUsed = true;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * punchForce, ForceMode2D.Impulse);
    }

    private void Spin()
    {
        canSpin = true;
        rb.AddForce(new Vector2(MoveInput * SpinForce, 0f), ForceMode2D.Force);

        OnCSSpin?.Invoke(true);
    }

    private void StopSpinAnimation()
    {
        canSpin = false;
        OnCSSpin?.Invoke(false);
    }

    private void UpdateAim(Vector2 dir)
    {
        aimDir = dir;
    }

    private void Attack()
    {

        Collider2D[] Coll = Physics2D.OverlapCircleAll(transform.position, AttackRadius);
    
            // cambiar el transform por un empty object que sea el punto de disparo y refereciarlo a aqui
        GameObject bullet = Instantiate(balaMetalicaPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = aimDir * bulletSpeed;
    


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

}
