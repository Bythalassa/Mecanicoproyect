using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class NewScriptableObjectScript : ScriptableObject
{
    public string EntityName;
    public int EntityID;
    public int HealthAmount;
    public int Speed;
    public int Damage;
    public Sprite EntitySprite;
    public Animator EntityAnimator;
}
