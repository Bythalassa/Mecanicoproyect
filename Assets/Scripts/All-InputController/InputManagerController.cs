
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum CharacterType 
{ 
    Clockborg, 
    Clocksiniester, 
    Birdbot 
}

public static class InputManagerController
{
    public static InputActionsGeneral Inputs { get; private set; }

    public static CharacterType Current { get; private set; }
    public static event Action<CharacterType> OnCharacterChanged;
   
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        
        Inputs = new InputActionsGeneral();
        Inputs.Transformation.Enable();
        SwitchTo(CharacterType.Clockborg);

        Inputs.Transformation.Clocksiniester.performed += OnClocksiniesterPerformed;
        Inputs.Transformation.Birdbot.performed += OnBirdbotPerformed;

        OnCharacterChanged += SwitchTo;
    }
    
    public static void SwitchTo(CharacterType character)
    {
        switch (character)
        {
            case CharacterType.Clockborg: 
                Inputs.Clockborg.Enable();
                Debug.Log("Clockborg enable");

                Inputs.Clocksiniester.Disable();
                Debug.Log("Clocksiniester Disable");

                Inputs.Birdbot.Disable();
                Debug.Log("Birdbot Disable");
                break;        

            case CharacterType.Clocksiniester:
                Inputs.Clocksiniester.Enable();
                Debug.Log("clocksiniester enable");

                Inputs.Clockborg.Disable();
                Debug.Log("Clockborg Disable");
                Inputs.Birdbot.Disable();
                Debug.Log("Birdbot Disable");


                break;

            case CharacterType.Birdbot:
                Inputs.Birdbot.Enable();
                Debug.Log(" Birdbit enable");
                Inputs.Clockborg.Disable();
                Debug.Log("Clockborg Disable");
                Inputs.Clocksiniester.Disable();
                Debug.Log("Clocksiniester Disable");


                break;
        }
        Current = character;
    }

    private static void OnClocksiniesterPerformed(InputAction.CallbackContext context) 
    {
        Debug.Log("hi");
        
       CharacterType next = (Current == CharacterType.Clocksiniester)
            ? CharacterType.Clockborg
            : CharacterType.Clocksiniester;

        OnCharacterChanged?.Invoke(next);
    }

    private static void OnBirdbotPerformed(InputAction.CallbackContext context)
    {
        CharacterType next = (Current == CharacterType.Birdbot)
            ? CharacterType.Clockborg
            : CharacterType.Birdbot;
        OnCharacterChanged?.Invoke(next);
    }



}




