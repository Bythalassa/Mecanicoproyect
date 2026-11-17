using UnityEngine;

public class MuroRompible2D : MonoBehaviour
{
    [Header("Resistencia del muro")]
    [SerializeField] private float vidaMaxima = 30f;

    private float vidaActual;
    private bool destruido = false;

    private void Awake()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(float danio)
    {
        if (destruido || danio <= 0f) return;

        vidaActual -= danio;

        Debug.Log("Muro golpeado. Vida restante: " + vidaActual);

        if (vidaActual <= 0f)
        {
            RomperMuro();
        }
    }

    private void RomperMuro()
    {
        destruido = true;

        Debug.Log("¡El muro se ha destruido!");

        Destroy(gameObject);
    }
}