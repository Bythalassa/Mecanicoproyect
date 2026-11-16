/*
    - [ ] y.Y*/


using System;
using UnityEngine;

public class BirdbotInputController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 13f;
    private Rigidbody2D rb; 

    public float MoveInput;

    [Header("Player_riding Check")]
    public bool Isriding;


    private void OnEnable()
    {
        InputBirdbotController.Fly += OnFly;

    }

    private void OnDisable()
    {
        InputBirdbotController.Fly -= OnFly;
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

        if (!Isriding) return;

        MoveInput = input.x;
    }

}


