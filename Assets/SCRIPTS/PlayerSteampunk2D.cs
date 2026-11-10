
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerSteampunk2D : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float fuerzaSalto = 10f;

    [Header("Deteccion del suelo")]
    [SerializeField] private Transform puntoSuelo;
    [SerializeField] private float radioSuelo = 0.2f;
    [SerializeField] private LayerMask capaSuelo;

    [Header("Ataque basico")]
    [SerializeField] private Transform puntoAtaque;
    [SerializeField] private float radioAtaque = 0.7f;
    [SerializeField] private float danio = 10f;
    [SerializeField] private float tiempoEntreAtaques = 0.4f;
    [SerializeField] private LayerMask capaEnemigos;

    [Header("Efectos FEEL")]
    [SerializeField] private CameraShake camaraShake;

    private Rigidbody2D rb;
    private float movimientoX;
    private float siguienteAtaque;
    private Vector3 escalaOriginal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        escalaOriginal = transform.localScale;
    }

    private void Update()
    {
        if (Keyboard.current != null)
        {
            LeerMovimiento();
            Saltar();
            GirarPersonaje();
        }

        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            Atacar();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            movimientoX * velocidad,
            rb.linearVelocity.y
        );
    }

    private void LeerMovimiento()
    {
        movimientoX = 0f;

        if (Keyboard.current.aKey.isPressed ||
            Keyboard.current.leftArrowKey.isPressed)
        {
            movimientoX = -1f;
        }

        if (Keyboard.current.dKey.isPressed ||
            Keyboard.current.rightArrowKey.isPressed)
        {
            movimientoX = 1f;
        }
    }

    private void Saltar()
    {
        if (puntoSuelo == null) return;

        bool enSuelo = Physics2D.OverlapCircle(
            puntoSuelo.position,
            radioSuelo,
            capaSuelo
        );

        if (Keyboard.current.spaceKey.wasPressedThisFrame
            && enSuelo)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                fuerzaSalto
            );
        }
    }

    private void GirarPersonaje()
    {
        if (movimientoX == 0f) return;

        float direccion = Mathf.Sign(movimientoX);

        transform.localScale = new Vector3(
            Mathf.Abs(escalaOriginal.x) * direccion,
            escalaOriginal.y,
            escalaOriginal.z
        );
    }

    private void Atacar()
    {
        if (Time.time < siguienteAtaque) return;
        if (puntoAtaque == null) return;

        siguienteAtaque = Time.time + tiempoEntreAtaques;

        Debug.Log("El robot realizo un ataque");

        Collider2D[] enemigos = Physics2D.OverlapCircleAll(
            puntoAtaque.position,
            radioAtaque,
            capaEnemigos
        );

        bool golpeConectado = false;

        foreach (Collider2D enemigo in enemigos)
        {
            golpeConectado = true;

            enemigo.SendMessageUpwards(
                "RecibirDanio",
                danio,
                SendMessageOptions.DontRequireReceiver
            );
        }

        if (golpeConectado)
        {
            Debug.Log("Golpe conectado");

            if (camaraShake != null)
            {
                camaraShake.Sacudir();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (puntoSuelo != null)
        {
            Gizmos.color = Color.green;

            Gizmos.DrawWireSphere(
                puntoSuelo.position,
                radioSuelo
            );
        }

        if (puntoAtaque != null)
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(
                puntoAtaque.position,
                radioAtaque
            );
        }
    }
}