using UnityEngine;
using static Enum;

[CreateAssetMenu(fileName = "AereoSO", menuName = "Scriptable Objects/AereoSO")]
public class AereoSO : ScriptableObject
{
    public RecoveryType recoveryType;

    public int Damage;

    public GameObject bullet;

    public CooldownType cooldowntype;

    bool Onactivate;

}
