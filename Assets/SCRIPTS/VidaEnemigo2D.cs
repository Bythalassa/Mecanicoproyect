using UnityEngine;

public class VidaEnemigo2D : MonoBehaviour
{
    [Header("Vida del enemigo")]
    [SerializeField] private float vidaMaxima = 50f;

    private float vidaActual;
    private bool muerto = false;

    private void Awake()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(float cantidad)
    {
        if (muerto || cantidad <= 0f) return;

        vidaActual -= cantidad;

        Debug.Log("Vida del enemigo: " + vidaActual);

        if (vidaActual <= 0f)
        {
            muerto = true;
            Debug.Log("Enemigo derrotado");
            Destroy(gameObject);
        }
    }
}