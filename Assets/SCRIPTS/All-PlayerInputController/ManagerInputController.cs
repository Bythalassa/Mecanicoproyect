using System;
using UnityEngine;

public class ManagerInputController : MonoBehaviour
{
    public GameObject clockborgPrefab;
    public GameObject clocksiniesterPrefab;
    public GameObject birdbotPrefab;

    private GameObject current;

    private void Update()
    {


    }

    private void OnEnable()
    { 
        InputManagerController.OnCharacterChanged += CharacterChanged;
    }

    private void OnDisable()
    {
        InputManagerController.OnCharacterChanged -= CharacterChanged;

    }

    private void CharacterChanged(CharacterType Clocksiniesters)
    {
        if (InputManagerController.Current == CharacterType.Clockborg)
        {
            current = clockborgPrefab;
        }
        else if (InputManagerController.Current == CharacterType.Clocksiniester)
        {
            current = clocksiniesterPrefab;
        }
        else if (InputManagerController.Current == CharacterType.Birdbot)
        {
            current = birdbotPrefab;
        }
        else
        {
            current = clockborgPrefab;
        }

    }




}
