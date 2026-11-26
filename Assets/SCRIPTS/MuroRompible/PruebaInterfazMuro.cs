using UnityEngine;
using UnityEngine.InputSystem;

public class PruebaInterfazMuro : MonoBehaviour
{
    [Header("Deteccion del muro")]
    [SerializeField] private Transform puntoAtaque;
    [SerializeField] private float radioAtaque = 0.7f;
    [SerializeField] private LayerMask capaMuro;

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            ProbarAtaque();
        }
    }

    private void ProbarAtaque()
    {
        if (puntoAtaque == null) return;

        Collider2D[] objetos = Physics2D.OverlapCircleAll(
            puntoAtaque.position,
            radioAtaque,
            capaMuro
        );

        foreach (Collider2D objeto in objetos)
        {
            IBreakWall muro =
                objeto.GetComponentInParent<IBreakWall>();

            if (muro != null)
            {
                muro.Attack2();

                Debug.Log(
                    "Attack2 ejecutado mediante IBreakWall"
                );
            }
        }
    }
}