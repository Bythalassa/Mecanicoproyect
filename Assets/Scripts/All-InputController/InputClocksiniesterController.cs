
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputClocksiniesterController
{
    private static InputActionsGeneral inputs;

    #region Clocksiniester Events

    public static Action<Vector2> OnWalkUpsidedown;
    public static Action OnCSShortJump;
    public static Action OnPunchImpulse;
    public static Action OnCSSpin;
    public static Action OnCSSpinFinish;
    public static Action OnAttack;
    public static Action OnSpeedGear;

    #endregion

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    public static void Initialize()
    {
        inputs = new InputActionsGeneral();
        inputs.Enable();

        inputs.Clocksiniester.WalkUpsidedown.performed += OnWalkUpsidedownPerformed;
        inputs.Clocksiniester.WalkUpsidedown.canceled += OnWalkUpsidedownCanceled;
        inputs.Clocksiniester.Jump.performed += OnShortJumpPerformed;
        inputs.Clocksiniester.PunchImpulse.performed += OnPunchImpulsePerformed;
        inputs.Clocksiniester.Spin.performed += OnSpinPerformed;
        inputs.Clocksiniester.Spin.canceled += OnSpinCanceled;
        inputs.Clocksiniester.Attack.performed += OnAttackPerformed;
        inputs.Clocksiniester.Speedgear.performed += OnSpeedGearPerformed;

    }

    private static void OnWalkUpsidedownPerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        OnWalkUpsidedown?.Invoke(moveInput);
    }

    public static Vector2 GetActualWalkDir()
    {
        return inputs.Clocksiniester.WalkUpsidedown.ReadValue<Vector2>();
    }

    private static void OnWalkUpsidedownCanceled(InputAction.CallbackContext context)
    {
        OnWalkUpsidedown?.Invoke(Vector2.zero);
    }

    private static void OnShortJumpPerformed(InputAction.CallbackContext context)
    {
        OnCSShortJump?.Invoke();
    }

    private static void OnPunchImpulsePerformed(InputAction.CallbackContext context)
    {
        OnPunchImpulse?.Invoke();
    }
    private static void OnSpinPerformed(InputAction.CallbackContext context)
    {
        OnCSSpin?.Invoke();
    }

    private static void OnSpinCanceled(InputAction.CallbackContext context)
    {
        OnCSSpinFinish?.Invoke();

    }

    private static void OnAttackPerformed(InputAction.CallbackContext context)
    {
        OnAttack?.Invoke();
    }
    private static void OnSpeedGearPerformed(InputAction.CallbackContext context)
    {
        OnSpeedGear?.Invoke();
    }

}