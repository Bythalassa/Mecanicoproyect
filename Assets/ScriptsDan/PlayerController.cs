using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputMaangerController
{

    private static InputSystem_Actions inputs;

    public Action<Vector2> OnMove;
    public Action OnJump;


    public static void Initialize()
    {
        inputs = new InputSystem_Actions();
        inputs.Enable();

        //inputs.Player.Move.performed += OnMovementPerformed;
        //inputs.Player.Move.performed += OnMovementCanceled;

    }

    //private static void OnMovementPerformed(InputAction.CALLBACK)
    //{

    //}




}
