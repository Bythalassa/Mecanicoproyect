using UnityEngine;
using static Enum;

[CreateAssetMenu(fileName = "TerrestreSO", menuName = "Scriptable Objects/TerrestreSO")]
public class NewScriptableObjectScript : ScriptableObject
{
    public RecoveryType recoveryType;

    public int Damage;

    public GameObject bullet;

    bool Onactivate;

}
