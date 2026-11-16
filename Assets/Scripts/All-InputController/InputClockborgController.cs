using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputClockborgController : MonoBehaviour
{
    private static InputActionsGeneral inputs;

    #region Clockborg Events 

    public static Action<Vector2> OnMove;
    public static Action OnStepBack;
    public static Action OnCBShortJump;
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
        inputs.Clockborg.StepBack.performed += OnStepBackPerformed;
        inputs.Clockborg.Jump.performed += OnJumpPerformed;
        inputs.Clockborg.Spin.performed += OnSpinPerformed;
        inputs.Clockborg.CallBirdbot.performed += OnCallBirdbotPerformed;

        #endregion
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
        OnCBShortJump?.Invoke();
    }

    private static void OnSpinPerformed(InputAction.CallbackContext context)
    {
        OnCBSpin?.Invoke();
    }

    private static void OnCallBirdbotPerformed(InputAction.CallbackContext context)
    {
        OnCallBirdbot?.Invoke();
    }





}
