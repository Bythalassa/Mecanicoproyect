
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamageable, ISlowdownable
{
    [Header("Vida del enemigo")]
    [SerializeField] private float vidaMaxima = 100f;
    [SerializeField] private float danioRecibido = 10f;

    [Header("Cooldown de ataques")]
    [SerializeField] private float cooldownFast = 0.5f;
    [SerializeField] private float cooldownMedium = 1f;
    [SerializeField] private float cooldownSlow = 2f;

    [Header("Movimiento del enemigo")]
    [SerializeField] protected Transform jugador;
    [SerializeField] protected float velocidadMovimiento = 3f;
    [SerializeField] protected float distanciaAtaque = 1.2f;

    [Header("Referencias del ataque")]
    [SerializeField] protected ProyectilEnemigoSpeedGear2D prefabAtaque;
    [SerializeField] protected Transform puntoDisparo;

    protected float vidaActual;
    protected float tiempoEntreAtaquesActual;
    protected CooldownType cooldownActual;

    private Rigidbody2D rb;
    private float cooldownBaseActual;
    private float tiempoAcumuladoAtaque;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        vidaMaxima = Mathf.Max(1f, vidaMaxima);
        vidaActual = vidaMaxima;

        ActualizarCooldown();
    }

    // RECIBIR DAÑO
    public virtual void TakeDamage()
    {
        RecibirDanio(danioRecibido);
    }

    public virtual void RecibirDanio(float cantidad)
    {
        if (vidaActual <= 0f || cantidad <= 0f)
            return;

        vidaActual = Mathf.Max(0f, vidaActual - cantidad);

        Debug.Log(name + " Vida restante: " + vidaActual);

        ActualizarCooldown();

        if (vidaActual <= 0f)
        {
            SwitchTo(EnemyStates.OnDeath);
        }
    }

    // COOLDOWN SEGUN PORCENTAJE DE VIDA
    private void ActualizarCooldown()
    {
        float porcentaje = vidaActual / vidaMaxima;

        if (porcentaje >= 0.75f)
            cooldownActual = CooldownType.Fast;
        else if (porcentaje >= 0.25f)
            cooldownActual = CooldownType.Medium;
        else
            cooldownActual = CooldownType.Slow;

        SwitchTo(cooldownActual);
    }

    protected virtual void SwitchTo(CooldownType current)
    {
        switch (current)
        {
            case CooldownType.Fast:
                cooldownBaseActual = cooldownFast;
                break;

            case CooldownType.Medium:
                cooldownBaseActual = cooldownMedium;
                break;

            case CooldownType.Slow:
                cooldownBaseActual = cooldownSlow;
                break;
        }

        cooldownBaseActual = Mathf.Max(0.05f, cooldownBaseActual);

        float factor = Mathf.Max(
            0.01f,
            SpeedGearManager.VelocidadGlobal
        );

        tiempoEntreAtaquesActual = cooldownBaseActual / factor;
    }

    // PERSECUCION COMPARTIDA
    protected void PerseguirJugador()
    {
        if (jugador == null || rb == null)
            return;

        Vector2 direccion =
            (Vector2)jugador.position - rb.position;

        if (direccion.magnitude <= distanciaAtaque)
            return;

        float velocidadActual =
            velocidadMovimiento *
            SpeedGearManager.VelocidadGlobal;

        rb.MovePosition(
            rb.position +
            direccion.normalized *
            velocidadActual *
            Time.fixedDeltaTime
        );
    }

    // DISPARO COMPARTIDO
    protected void IntentarAtacar()
    {
        if (jugador == null ||
            prefabAtaque == null ||
            puntoDisparo == null)
            return;

        // El reloj del enemigo avanza mas lento
        // cuando Speed Gear esta activado.
        tiempoAcumuladoAtaque +=
            Time.fixedDeltaTime *
            SpeedGearManager.VelocidadGlobal;

        if (tiempoAcumuladoAtaque < cooldownBaseActual)
            return;

        tiempoAcumuladoAtaque = 0f;

        ProyectilEnemigoSpeedGear2D proyectil =
            Instantiate(
                prefabAtaque,
                puntoDisparo.position,
                Quaternion.identity
            );

        Vector2 direccion =
            (Vector2)jugador.position -
            (Vector2)puntoDisparo.position;

        if (direccion.sqrMagnitude < 0.001f)
            direccion = Vector2.left;

        proyectil.Inicializar(direccion.normalized);

        // Evita acumular balas indefinidamente.
        Destroy(proyectil.gameObject, 5f);

        Debug.Log(name + " disparo su ataque");
    }

    // SPEED GEAR
    public virtual void Slowdown()
    {
        SwitchTo(cooldownActual);
    }

    // ESTADOS DE CADA ENEMIGO
    protected abstract void SwitchTo(EnemyStates current);

    // RECUPERACION PENDIENTE
    protected virtual void SwitchTo(RecoveryType current)
    {
        switch (current)
        {
            case RecoveryType.EasyIn:
                break;

            case RecoveryType.EasyOut:
                break;

            case RecoveryType.EasyOutEasyIn:
                break;

            case RecoveryType.EasyInEasyOut:
                break;
        }
    }
}
