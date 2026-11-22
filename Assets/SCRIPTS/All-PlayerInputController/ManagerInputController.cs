using System;
using UnityEngine;

public class ManagerInputController : MonoBehaviour
{
    public GameObject clockborgPrefab;
    public GameObject clocksiniesterPrefab;
    public GameObject birdbotPrefab;

    private GameObject current;
   
    
    [Header("Countdown Delay BirdOnEnable")]
    private float DelaySpawn = 1.5f;
    private float timer;
    public static event Action BirdAppears;


    private void Start()
    {
        CharacterChanged(InputManagerController.Current);
    }

    private void Update()
    {
        if (InputManagerController.Current == CharacterType.Birdbot && !birdbotPrefab.activeSelf)
        //ActiveSelf es
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);

            if (timer <= 0f)
            {
                clockborgPrefab.SetActive(false);
                clocksiniesterPrefab.SetActive(false);
                birdbotPrefab.SetActive(true);

                BirdAppears?.Invoke();
            }
        }

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
            timer = DelaySpawn;
        }
        else
        {
            clockborgPrefab.SetActive(true);
            clocksiniesterPrefab.SetActive(false);
            birdbotPrefab.SetActive(false);
        }

    }




}
