using UnityEngine;

public class RecolectarAmmo2D : MonoBehaviour
{
    [Header("Configuracion de AMMO")]
    [SerializeField] private int cantidadMunicion = 3;

    private void OnTriggerEnter2D(Collider2D otro)
    {
        DisparoBasico2D disparo =
            otro.GetComponentInParent<DisparoBasico2D>();

        if (disparo == null) return;

        disparo.RecogerMunicion(cantidadMunicion);

        Debug.Log("¡bala recolectada muchacho!");

        Destroy(gameObject);
    }
}
