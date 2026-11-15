/*
 *  This is how all inputs will figure their way out and in
  - Movement "wasd"
  - Spin "s"
  - Jump "space"
  - Punch Impulse "C"
  - Attack "left click"
  - Speed Gear "right click"    
  - Transformation "Q" 
  - Call Birdbot "T"

*/


using System;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputManagerController
{
    private static PlayerInp_Actions inputs;

    public static Action<Vector2> OnMove;
    public static Action OnStepBack;
    public static Action OnJump;
    public static Action OnPunchImpulse;
    public static Action OnSpin;
    public static Action OnAttack;
    public static Action OnSpeedGear;   
    public static Action OnTransformation;
    public static Action OnCallBirdbot;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        inputs = new PlayerInp_Actions();
        inputs.Enable();

        inputs.Player.Movement.performed += OnMovementPerformed;
        inputs.Player.Movement.canceled += OnMovementCanceled;
        inputs.Player.StepBack.performed += OnStepBackPerformed;
        inputs.Player.Jump.performed += OnJumpPerformed;
        inputs.Player.PunchImpulse.performed += OnPunchImpulsePerformed;
        inputs.Player.Spin.performed += OnSpinPerformed;
        inputs.Player.Attack.performed += OnAttackPerformed;





        /* set names to the actual actions + first define what should the output bee: Performed, Canceled. OnPerformed
         later in PlayerController values are added so --> I should name the file ClockborgManagerController, 
        --> add a ClocksiniesterManagerController y --> add BirdbotManagerController // this scripts will be added to define each character´s Metrics
        PlayerAnimatorController sehr an der ende bitteshon
        movement(done)
        public static Action OnStepBack;
        jump (done)
            public static Action OnPunchImpulse; 
            public static Action OnSpin;
            public static Action OnAttack; (done)
            public static Action OnSpeedGear;   
            public static Action OnTransformation;
            public static Action OnCallBirdbot;

         */

    }

    private static void OnMovementPerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        OnMove?.Invoke(moveInput);
    }

    private static void OnMovementCanceled(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(Vector2.zero);
    }

    private static void OnStepBackPerformed(InputAction.CallbackContext context)
    {
        OnStepBack?.Invoke();
    }

    private static void OnJumpPerformed(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    private static void OnPunchImpulsePerformed(InputAction.CallbackContext context)
    {
        OnPunchImpulse?.Invoke();
    }

    private static void OnSpinPerformed(InputAction.CallbackContext context)
    {
        OnSpin?.Invoke();
    }

    private static void OnAttackPerformed(InputAction.CallbackContext context)
    {
        OnAttack?.Invoke();
    }



}




