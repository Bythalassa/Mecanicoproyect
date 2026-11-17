using UnityEngine;
using static Enum;

[CreateAssetMenu(fileName = "AmbientalSO", menuName = "Scriptable Objects/AmbientalSO")]

public class AmbientalSO : ScriptableObject
{
    public RecoveryType recoveryType;

    public int Damage;

    public GameObject bullet;

    bool Onactivate;

}
