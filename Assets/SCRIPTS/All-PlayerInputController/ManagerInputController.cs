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

    private void Start()
    {
        CharacterChanged(InputManagerController.Current);
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
            clockborgPrefab.SetActive(true);
            clocksiniesterPrefab.SetActive(false);
            birdbotPrefab.SetActive(false);

        }
        else if (InputManagerController.Current == CharacterType.Clocksiniester)
        {
            clockborgPrefab.SetActive(false);
            clocksiniesterPrefab.SetActive(true);
            birdbotPrefab.SetActive(false);
        }
        else if (InputManagerController.Current == CharacterType.Birdbot)
        {
            clockborgPrefab.SetActive(false);
            clocksiniesterPrefab.SetActive(false);
            birdbotPrefab.SetActive(true);
        }
        else
        {
            clockborgPrefab.SetActive(true);
            clocksiniesterPrefab.SetActive(false);
            birdbotPrefab.SetActive(false);
        }

    }




}
