
using UnityEngine;

public class MovimientoEnemigoPruebaSpeedGear2D
    : MonoBehaviour, ISlowdownable
{
    [Header("Movimiento de prueba")]
    [SerializeField] private float velocidad = 3f;
    [SerializeField] private float distancia = 2f;

    private Vector3 posicionInicial;
    private float recorrido;
    private float multiplicador = 1f;

    private void Start()
    {
        posicionInicial = transform.position;
        Slowdown();
    }

    private void Update()
    {
        recorrido += Time.deltaTime * velocidad * multiplicador;

        float desplazamiento = Mathf.PingPong(
            recorrido,
            distancia
        );

        transform.position = posicionInicial +
            Vector3.right * desplazamiento;
    }

    public void Slowdown()
    {
        multiplicador = SpeedGearManager.VelocidadGlobal;

        Debug.Log(
            "Velocidad del enemigo actualizada: " +
            velocidad * multiplicador
        );
    }
}
