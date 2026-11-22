using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputBirdbotController 
{
    private static InputActionsGeneral inputs;
    
    public static Action<Vector2> Fly;
    public static Action Jump;
    public static Action FlyAway;
  
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    public static void Initialize()
    {
        inputs = new InputActionsGeneral();
        inputs.Enable();

        inputs.Birdbot.Fly.performed += OnFlyPerformed;
        inputs.Birdbot.Fly.canceled += OnFlyCanceled;
        inputs.Birdbot.Jump.performed += OnJumpPerformed;
        inputs.Birdbot.FinishRide.performed += OnFinishRidePerformed;

    }

    private static void OnFlyPerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        Fly?.Invoke(moveInput);
    }

    private static void OnFlyCanceled(InputAction.CallbackContext context)
    {
        Fly?.Invoke(Vector2.zero);
    }

    private static void OnJumpPerformed(InputAction.CallbackContext context)
    {
        Jump?.Invoke();
    }

    private static void OnFinishRidePerformed(InputAction.CallbackContext context)
    {
        FlyAway?.Invoke();
    }

}