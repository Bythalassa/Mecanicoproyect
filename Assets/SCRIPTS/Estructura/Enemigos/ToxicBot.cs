
using UnityEngine;

public class ToxicBot : BaseEnemy
{
    protected override void SwitchTo(CooldownType current)
    {
        base.SwitchTo(current);
    }

    protected override void SwitchTo(EnemyStates current)
    {
        switch (current)
        {
            case EnemyStates.Born:
                break;

            case EnemyStates.FoundPlayer:
                break;

            case EnemyStates.CycleAround:
                break;

            case EnemyStates.TakeDamage:
                break;

            case EnemyStates.OnDeath:
                break;
        }
    }

    protected override void SwitchTo(RecoveryType current)
    {
        base.SwitchTo(current);
    }

    protected virtual void ChaseEntity()
    {
        // Pendiente: comportamiento de persecucion.
    }
}
