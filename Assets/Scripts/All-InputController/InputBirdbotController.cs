using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputBirdbotController : MonoBehaviour
{
    private static InputActionsGeneral inputs;

    #region Birdbot Events 
    public static Action OnCall; 
    public static Action <Vector2>Fly;
    public static Action OnFlyAway;
    #endregion

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    public static void Initialize()
    {
        inputs = new InputActionsGeneral();
        inputs.Enable();

        #region Birdbot Action Map  [all actions in Birdbot]

        inputs.Birdbot.Fly.performed += OnFlyPerformed;
        inputs.Birdbot.Fly.canceled += OnFlyCanceled;

        #endregion
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


}