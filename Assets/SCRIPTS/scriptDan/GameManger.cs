using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()

    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public int score;

    /* pensar en un Singletone Manager
    //en base a actions que manejen la interacción de diferentes managers/sistemas 
    a un maanger padre
    */






}
