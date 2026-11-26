using UnityEngine;
using UnityEngine.UI;

public class HUDVidaPlayer : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private VidaPlayerPrueba2D vidaJugador;
    [SerializeField] private Image barraVida;

    private void Update()
    {
        barraVida.fillAmount = vidaJugador.ObtenerPorcentajeVida();
    }
}
