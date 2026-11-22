

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProyectilEnemigoSpeedGear2D : MonoBehaviour, ISlowdownable
{
    [Header("Movimiento del proyectil")]
    [SerializeField] private float velocidadBase = 6f;
    [SerializeField] private Vector2 direccion = Vector2.left;

    private Rigidbody2D rb;
    private bool impactoRegistrado = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AplicarVelocidad();
    }

    // DIRECCION DEL PROYECTIL
    public void Inicializar(Vector2 nuevaDireccion)
    {
        if (nuevaDireccion == Vector2.zero)
            return;

        direccion = nuevaDireccion.normalized;
        AplicarVelocidad();
    }

    // INTERFAZ ISLOWDOWNABLE
    public void Slowdown()
    {
        AplicarVelocidad();
    }

    // VELOCIDAD SEGUN SPEED GEAR
    private void AplicarVelocidad()
    {
        if (rb == null) return;

        rb.linearVelocity =
            direccion.normalized *
            velocidadBase *
            SpeedGearManager.VelocidadGlobal;
    }

    // DETECCION DEL IMPACTO
    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (impactoRegistrado) return;

        // Solo las balas enemigas dañan al Player
        if (!otro.transform.root.CompareTag("Player"))
            return;

        // Buscar la interfaz en el objeto impactado
        IDamageable objetivo =
            otro.GetComponentInParent<IDamageable>();

        if (objetivo == null) return;

        impactoRegistrado = true;

        // Ejecutar el daño mediante la interfaz
        objetivo.TakeDamage();

        Debug.Log("Daño aplicado mediante IDamageable");

        Destroy(gameObject);
    }
}
