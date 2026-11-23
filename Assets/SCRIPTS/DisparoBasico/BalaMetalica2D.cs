using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BalaMetalica2D : MonoBehaviour
{
    [Header("Configuracion de la bala")]
    [SerializeField] private float velocidad = 12f;
    [SerializeField] private float danio = 10f;
    [SerializeField] private float tiempoVida = 3f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    public void Inicializar(float direccion)
    {
        rb.linearVelocity = new Vector2(
            Mathf.Sign(direccion) * velocidad,
            0f
        );
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        // Evitamos que la bala choque con nuestro Player de prueba.
        if (otro.GetComponentInParent<PlayerSteampunk2D>() != null)
            return;

        otro.SendMessageUpwards(
            "RecibirDanio",
            danio,
            SendMessageOptions.DontRequireReceiver
        );

        Destroy(gameObject);
    }
}
