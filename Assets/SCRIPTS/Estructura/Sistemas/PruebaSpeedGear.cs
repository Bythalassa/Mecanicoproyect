
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpeedGearManager))]
public class PruebaSpeedGear : MonoBehaviour
{
    private SpeedGearManager speedGear;

    private void Awake()
    {
        speedGear = GetComponent<SpeedGearManager>();
    }

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            speedGear.AlternarSpeedGear();
        }
    }
}
