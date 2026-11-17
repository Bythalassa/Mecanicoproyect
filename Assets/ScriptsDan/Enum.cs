 using UnityEngine;

public class Enum
{ 
    public enum TargetType
    { 
        Troops,
        Building,
        All1
    }

    public enum CooldownType
    { 
        Slow,
        Normal,
        Fast
    }

    public enum SpecialModifierType
    {
        None, // 0000
        InvokeEveryTick, //0001
        InvokeOnDeath, //0010
        ExplotionOnDeath,
        BuffoEvertTime,

    }

    public enum EnemyType
    {
        Aereo,
        Terrestre,
    }

    public enum RecoveryType
    {
        EaseIn,
        EaseOut,
        EaseOutIn,
        EaseInOut,

    }



}
