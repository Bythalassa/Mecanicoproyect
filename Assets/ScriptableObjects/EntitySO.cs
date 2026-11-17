using UnityEngine;
using static Enum;

[CreateAssetMenu(fileName = "EntitySO", menuName = "Scriptable Objects/EntitySO")]
public class EntitySO : ScriptableObject

{

    public string EntityName;

    public int EntityID;

    public int Healing;

    public SpecialModifierType SpecialModifier;

    public int Damage;

    public Sprite EntitySprite;

    public Animator EntityAnimator;

    /*
     Información del enemigo:
    - int AAmount
    //ver el proyecto de la gran mesa lo que hiso jere
     
     */

   

}
