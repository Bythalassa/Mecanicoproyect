/*
    - [ ] y.Y*/

using System;
using UnityEngine;

public class BirdbotInputController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 13f;
    public float MoveInput;


    private Rigidbody2D rb;

    public static event Action OnHit;
    //public static event Action desaparecer;

    private void OnEnable()
    {
        InputBirdbotController.Fly += OnFly;
        //el timbre de desaparecer lo va a tocar transformation - paciencia  a que eso este
    }

    private void OnDisable()
    {
        InputBirdbotController.Fly -= OnFly;
        //el timbre de desaparecer lo va a tocar transformation - paciencia  a que eso este
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


