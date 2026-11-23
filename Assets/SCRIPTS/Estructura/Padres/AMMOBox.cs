
using UnityEngine;

public class AMMOBox : MonoBehaviour, ICollectable
{
    [Header("Configuracion de AMMO")]
    [SerializeField] private int cantidadMunicion = 3;

    private DisparoBasico2D disparoJugador;
    private bool recolectado = false;

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (recolectado) return;

        disparoJugador =
            otro.GetComponentInParent<DisparoBasico2D>();

        if (disparoJugador == null) return;

        ICollectable coleccionable = this;
        coleccionable.Collect();
    }

    public void Collect()
    {
        if (recolectado || disparoJugador == null)
            return;

        recolectado = true;

        disparoJugador.RecogerMunicion(cantidadMunicion);

        Debug.Log("AMMO recolectada mediante ICollectable");

        Destroy(gameObject);
    }
}
