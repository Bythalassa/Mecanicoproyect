
using UnityEngine;

public class VidaPlayerPrueba2D : MonoBehaviour, IDamageable
{
    [Header("Vida del jugador")]
    [SerializeField] private float vidaMaxima = 100f;
    [SerializeField] private float danioPorImpacto = 10f;

    private float vidaActual;

    private void Awake()
    {
        vidaActual = vidaMaxima;
    }

    // Funcion de la interfaz IDamageable
    public void TakeDamage()
    {
        if (vidaActual <= 0f)
            return;

        vidaActual -= danioPorImpacto;
        vidaActual = Mathf.Max(0f, vidaActual);

        Debug.Log(
            "Player recibio daño. Vida restante: " +
            vidaActual
        );

        if (vidaActual <= 0f)
        {
            Debug.Log("Player derrotado");

            // No destruimos al Player porque
            // estamos realizando una prueba.
        }
    }
}
