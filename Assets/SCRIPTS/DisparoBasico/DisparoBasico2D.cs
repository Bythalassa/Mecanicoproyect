using UnityEngine;
using UnityEngine.InputSystem;

public class DisparoBasico2D : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private BalaMetalica2D balaPrefab;
    [SerializeField] private Transform puntoDisparo;

    [Header("Configuracion del disparo")]
    [SerializeField] private float tiempoEntreDisparos = 0.3f;

    private float siguienteDisparo;

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        if (Time.time < siguienteDisparo) return;
        if (balaPrefab == null || puntoDisparo == null) return;

        siguienteDisparo = Time.time + tiempoEntreDisparos;

        float direccion = Mathf.Sign(transform.localScale.x);

        BalaMetalica2D nuevaBala = Instantiate(
            balaPrefab,
            puntoDisparo.position,
            Quaternion.identity
        );

        nuevaBala.Inicializar(direccion);

        Debug.Log("Disparo metalico realizado");
    }
}
