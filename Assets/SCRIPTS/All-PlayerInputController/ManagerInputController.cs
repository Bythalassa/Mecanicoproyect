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
                Activate(birdbotPrefab);

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
            Activate(clockborgPrefab);

        }
        else if (InputManagerController.Current == CharacterType.Clocksiniester)
        {
            Activate(clocksiniesterPrefab);
        }
        else if (InputManagerController.Current == CharacterType.Birdbot)
        {
            timer = DelaySpawn;
        }
        else
        {
            Activate(clockborgPrefab);
        }
    }
        private void Activate(GameObject next)
        {
        if (current != null)
            next.transform.position = current.transform.position;

        clockborgPrefab.SetActive(next == clockborgPrefab);
        clocksiniesterPrefab.SetActive(next == clocksiniesterPrefab);
        birdbotPrefab.SetActive(next == birdbotPrefab);

        current = next;
         }

}





