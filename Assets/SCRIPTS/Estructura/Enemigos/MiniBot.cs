

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MiniBot : BaseEnemy
{
    [Header("Estado del enemigo")]
    [SerializeField] private EnemyStates estadoActual;

    private void Start()
    {
        SwitchTo(EnemyStates.Born);
    }

    private void FixedUpdate()
    {
        if (jugador == null) return;

        if (estadoActual != EnemyStates.Born &&
            estadoActual != EnemyStates.FoundPlayer)
            return;

        float distanciaJugador = Vector2.Distance(
            transform.position,
            jugador.position
        );

        if (distanciaJugador <= distanciaAtaque)
        {
            if (estadoActual != EnemyStates.FoundPlayer)
            {
                SwitchTo(EnemyStates.FoundPlayer);
            }

            // Usa el prefab particular del MiniBot.
            IntentarAtacar();
            return;
        }

        if (estadoActual != EnemyStates.Born)
        {
            SwitchTo(EnemyStates.Born);
        }

        PerseguirJugador();
    }

    protected override void SwitchTo(EnemyStates current)
    {
        estadoActual = current;

        switch (current)
        {
            case EnemyStates.Born:
                Debug.Log("MiniBot persiguiendo al Player");
                break;

            case EnemyStates.FoundPlayer:
                Debug.Log("MiniBot encontro al Player");
                break;

            case EnemyStates.CycleAround:
                // Pendiente.
                break;

            case EnemyStates.TakeDamage:
                // Pendiente.
                break;

            case EnemyStates.OnDeath:
                Debug.Log("MiniBot destruido");
                Destroy(gameObject);
                break;
        }
    }

    protected override void SwitchTo(CooldownType current)
    {
        base.SwitchTo(current);
    }

    protected override void SwitchTo(RecoveryType current)
    {
        base.SwitchTo(current);
    }
}
