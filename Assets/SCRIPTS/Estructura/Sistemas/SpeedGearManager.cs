
using UnityEngine;
using UnityEngine.InputSystem;

public class SpeedGearManager : MonoBehaviour
{
    [Header("Configuracion Speed Gear")]
    [Range(0.1f, 1f)]
    [SerializeField] private float factorLento = 0.3f;

    [Header("Control temporal independiente")]
    [SerializeField] private bool usarClickDerecho = true;

    public static float VelocidadGlobal { get; private set; } = 1f;
    public static bool EstaActivo { get; private set; }

    private void Update()
    {
        if (!usarClickDerecho || Mouse.current == null)
            return;

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            AlternarSpeedGear();
        }
    }

    public void ActivarSpeedGear()
    {
        if (EstaActivo) return;

        EstaActivo = true;
        VelocidadGlobal = factorLento;

        ActualizarObjetos();

        Debug.Log("Speed Gear activado");
    }

    public void DesactivarSpeedGear()
    {
        if (!EstaActivo) return;

        EstaActivo = false;
        VelocidadGlobal = 1f;

        ActualizarObjetos();

        Debug.Log("Speed Gear desactivado");
    }

    public void AlternarSpeedGear()
    {
        if (EstaActivo)
        {
            DesactivarSpeedGear();
        }
        else
        {
            ActivarSpeedGear();
        }
    }

    private void ActualizarObjetos()
    {
        MonoBehaviour[] componentes =
            FindObjectsByType<MonoBehaviour>(
                FindObjectsSortMode.None
            );

        foreach (MonoBehaviour componente in componentes)
        {
            if (componente is ISlowdownable objeto)
            {
                objeto.Slowdown();
            }
        }
    }

    private void OnDestroy()
    {
        EstaActivo = false;
        VelocidadGlobal = 1f;
    }
}

