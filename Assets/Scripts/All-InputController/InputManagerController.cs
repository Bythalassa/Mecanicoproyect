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

using UnityEngine;

public enum CharacterType 
{ 
    Clockborg, 
    Clocksinister, 
    Birdbot 
}

//YO CREO QUE este script deberia escuchar los timpres para cambiar de personaje //


public static class InputManagerController
{

    public static InputActionsGeneral Inputs { get; private set; }
    public static CharacterType Current { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        Inputs = new InputActionsGeneral();
        SwitchTo(CharacterType.Clockborg);

        Inputs.Enable();
    }

    public static void SwitchTo(CharacterType character)
    {
        Inputs.Clockborg.Disable();
        Inputs.Clocksiniester.Disable();
        Inputs.Birdbot.Disable();

        switch (character)
        {
            case CharacterType.Clockborg: Inputs.Clockborg.Enable(); break;
            case CharacterType.Clocksinister: Inputs.Clocksiniester.Enable(); break;
            case CharacterType.Birdbot: Inputs.Birdbot.Enable(); break;
        }
        Current = character;
    }
}




