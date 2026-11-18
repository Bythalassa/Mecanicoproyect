using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DisparoBasico2D : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private BalaMetalica2D balaPrefab;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private TMP_Text textoAMMO;

    [Header("Disparo")]
    [SerializeField] private float tiempoEntreDisparos = 0.3f;

    [Header("Municion")]
    [SerializeField] private int municionInicial = 5;
    [SerializeField] private int municionMaxima = 10;

    private int municionActual;
    private float siguienteDisparo;

    private void Awake()
    {
        municionMaxima = Mathf.Max(1, municionMaxima);
        municionActual = Mathf.Clamp(municionInicial, 0, municionMaxima);
        ActualizarAMMO();
    }

    private void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.fKey.wasPressedThisFrame)
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        if (Time.time < siguienteDisparo) return;
        if (balaPrefab == null || puntoDisparo == null) return;

        if (municionActual <= 0)
        {
            Debug.Log("Sin municion");
            return;
        }

        float direccion = Mathf.Sign(transform.localScale.x);

        BalaMetalica2D nuevaBala = Instantiate(
            balaPrefab,
            puntoDisparo.position,
            Quaternion.identity
        );

        nuevaBala.Inicializar(direccion);

        municionActual--;
        siguienteDisparo = Time.time + tiempoEntreDisparos;

        ActualizarAMMO();
    }

    public void RecogerMunicion(int cantidad)
    {
        if (cantidad <= 0) return;

        municionActual = Mathf.Min(
            municionActual + cantidad,
            municionMaxima
        );

        ActualizarAMMO();
    }

    private void ActualizarAMMO()
    {
        if (textoAMMO != null)
        {
            textoAMMO.text =
                "AMMO: " + municionActual + "/" + municionMaxima;
        }
    }
}