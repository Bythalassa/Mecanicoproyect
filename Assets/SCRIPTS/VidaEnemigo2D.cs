using System;
using UnityEngine;

public class VidaEnemigo2D : MonoBehaviour
{
    [Header("Vida del enemigo")]
    [SerializeField] private float vidaMaxima = 50f;

    private float vidaActual;
    private bool muerto = false;

    // EVENTOS ACTION
    public event Action<float, float> AlCambiarVida;
    public event Action AlRecibirDanio;
    public event Action AlMorir;

    private void Awake()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(float cantidad)
    {
        if (muerto || cantidad <= 0f) return;

        vidaActual = Mathf.Max(0f, vidaActual - cantidad);

        Debug.Log("Vida del enemigo: " + vidaActual);

        // Avisamos que cambio la vida
        AlCambiarVida?.Invoke(vidaActual, vidaMaxima);

        // Avisamos que recibio un golpe
        AlRecibirDanio?.Invoke();

        if (vidaActual <= 0f)
        {
            Morir();
        }
    }

    private void Morir()
    {
        if (muerto) return;

        muerto = true;

        Debug.Log("Enemigo derrotado");

        // Avisamos que el enemigo murio
        AlMorir?.Invoke();

        Destroy(gameObject);
    }
}