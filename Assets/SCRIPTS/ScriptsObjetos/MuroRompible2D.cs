
using UnityEngine;

public class MuroRompible2D : MonoBehaviour, IDamageable, IBreakWall
{
    [Header("Resistencia del muro")]
    [SerializeField] private float vidaMaxima = 10f;

    [Header("Daño mediante interfaces")]
    [SerializeField] private float danioPorInterfaz = 10f;

    private float vidaActual;
    private bool destruido = false;

    private void Awake()
    {
        vidaActual = vidaMaxima;
    }

    // Sistema de daño que ya utilizamos
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

    // Interfaz IDamageable
    public void TakeDamage()
    {
        RecibirDanio(danioPorInterfaz);
    }

    // Interfaz IBreakWall
    public void Attack2()
    {
        RecibirDanio(danioPorInterfaz);
    }

    private void RomperMuro()
    {
        destruido = true;

        Debug.Log("¡El muro se ha destruido!");

        Destroy(gameObject);
    }
}