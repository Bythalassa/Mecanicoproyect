using System;
using UnityEngine;
using UnityEngine.InputSystem;

/* El script AimController es clave para leer la dirección a la que el jugador debe disparar:
 * ACTION event AIMING dentro del Mouse.cs 
-    La declara este script
-    LA FUNCION se actualiza en update, consta en (de  MouseOnscreenviewport toca el timbre de leer el movimiento del mouse )
-    y la escucha el scipt Shoot Ability para usar de referencia direccion 
 */


public class AimController : MonoBehaviour
{

    public static event Action<Vector2> OnAim;
    private Vector2 currentAim;

    void Update()
    {
        Vector2 aim = AimDirection();
        Debug.Log(aim);

        if (aim != currentAim)
        {
            currentAim = aim;
            OnAim?.Invoke(aim);
        }
    }


    public Vector2 AimDirection()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (direction.y < 0) direction.y = 0;
        return (direction - (Vector2)transform.position).normalized;     
    }

}
