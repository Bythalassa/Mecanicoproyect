using System;

public enum TargetType
{
    Troops,
    Building,
    All
}
public enum SpeedType
{
    Slow,
    Normal,
    Fast
}
public enum SpecialModifierType
{
    None = 0,
    InvokeEveryTick = 1 << 1,
    InvokeOnDeath = 1 << 2,
}