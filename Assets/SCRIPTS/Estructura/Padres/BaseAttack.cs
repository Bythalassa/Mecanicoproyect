
using UnityEngine;

public abstract class BaseAttack : MonoBehaviour, ISlowdownable
{
    // Funcion de la interfaz ISlowdownable
    public virtual void Slowdown()
    {
        // Pendiente: implementar ralentizacion.
    }
}
