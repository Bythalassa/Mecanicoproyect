using UnityEngine;

[CreateAssetMenu(fileName = "EntityDataCO", menuName = "Scriptable Objects/EntityDataCO")]
public class EntityDataCO : ScriptableObject
{
    public string EntityName;
    public int EntityID;
    public int HealthAmount;
    public int Speed;
    public int Damage;
    public Sprite EntitySprite;
    public Animator EntityAnimator;
}
