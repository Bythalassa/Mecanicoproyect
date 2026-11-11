using UnityEngine;

public class FeedbackGolpeCamara : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private VidaEnemigo2D enemigo;

    private CameraShake camaraShake;

    private void Awake()
    {
        camaraShake = GetComponent<CameraShake>();
    }

    private void OnEnable()
    {
        if (enemigo != null)
        {
            enemigo.AlRecibirDanio += SacudirCamara;
        }
    }

    private void OnDisable()
    {
        if (enemigo != null)
        {
            enemigo.AlRecibirDanio -= SacudirCamara;
        }
    }

    private void SacudirCamara()
    {
        if (camaraShake != null)
        {
            camaraShake.Sacudir();
        }
    }
}