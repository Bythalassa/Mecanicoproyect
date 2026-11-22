/*
    - [ ] y.Y*/

using System;
using UnityEngine;

public class BirdbotInputController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 13f;
    public float MoveInput;
    public float jumpForce = 6;

    private Rigidbody2D rb;

    public static event Action OnHit;
    public static event Action BirdAppears2;

    private void OnEnable()
    {
        InputBirdbotController.Fly += OnFly;
        InputBirdbotController.FlyAway += FinishRide;
        InputBirdbotController.Jump += OnJump;
        ManagerInputController.BirdAppears += BirdAppearsDos;

    }

    private void OnDisable()
    {
        InputBirdbotController.Fly -= OnFly;
        InputBirdbotController.FlyAway -= FinishRide;
        InputBirdbotController.Jump -= OnJump;
        ManagerInputController.BirdAppears -= BirdAppearsDos;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(MoveInput * speed, rb.linearVelocity.y);
    }

    private void OnFly(Vector2 input)
    {
        MoveInput = input.x;
    }

    private void OnJump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

    }

    private void BirdAppearsDos()
    {
        BirdAppears2?.Invoke();
    }


    private void FinishRide()
    {
        //que se mueva en una dirección hacia la derecha
        




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

}


