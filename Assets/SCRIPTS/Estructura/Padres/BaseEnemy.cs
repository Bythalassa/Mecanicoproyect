using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamageable
{
    // Recibir daño mediante la interfaz
    public virtual void TakeDamage()
    {
        // Pendiente de implementar
    }

    // Estados de velocidad o cooldown
    protected virtual void SwitchTo(CooldownType current)
    {
        switch (current)
        {
            case CooldownType.Fast:
                break;

            case CooldownType.Medium:
                break;

            case CooldownType.Slow:
                break;
        }
    }

    // Cada enemigo definira sus propios estados
    protected abstract void SwitchTo(EnemyStates current);

    // Tipos de recuperacion
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