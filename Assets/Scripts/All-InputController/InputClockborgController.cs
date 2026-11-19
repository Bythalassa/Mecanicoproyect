using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputClockborgController
{
    private static InputActionsGeneral inputs;

    #region Clockborg Events 

    public static Action<Vector2> OnMovement;
    public static Action OnCBShortJump;
    public static Action OnCBPunchImpulse;
    public static Action OnCBSpin;
    public static Action OnCallBirdbot;

    #endregion

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    public static void Initialize()
    {
        inputs = new InputActionsGeneral();
        inputs.Enable();


        #region Clockborg Action Map  [all actions in Clockborg]

        inputs.Clockborg.Movement.performed += OnMovementPerformed;
        inputs.Clockborg.Movement.canceled += OnMovementCanceled;
        inputs.Clockborg.Jump.performed += OnJumpPerformed;
        inputs.Clockborg.PunchImpulse.performed += OnPunchImpulse;
        inputs.Clockborg.Spin.performed += OnSpinPerformed;

        #endregion
    }

    private static void OnMovementPerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        OnMovement?.Invoke(moveInput);
    }

    public static Vector2 GetActualWalkDir()
    {
        return inputs.Clockborg.Movement.ReadValue<Vector2>();
    }

    private static void OnMovementCanceled(InputAction.CallbackContext context)
    {
        OnMovement?.Invoke(Vector2.zero);
    }

    private static void OnJumpPerformed(InputAction.CallbackContext context)
    {
        OnCBShortJump?.Invoke();
    }


    private static void OnPunchImpulse(InputAction.CallbackContext context)
    {
        OnCBPunchImpulse?.Invoke();
    }
    private static void OnSpinPerformed(InputAction.CallbackContext context)
    {
        OnCBSpin?.Invoke();
    }


}
