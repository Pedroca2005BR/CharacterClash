using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Abilities/ImmunityAbility", order = 2)]
public class ImmunityAbility : Ability
{
    [Header("Attributes")]
    public int damageMultiplier = 0;
    public SkillSuperType superType;
    public SkillSubType subType;
    public bool chargesSpecial;

    public override void ActivateAbility(BaseCharacter character)
    {
        if (character.skillReceived.superType == superType || character.skillReceived.subTypes.Contains(subType))
        {
            character.damageToBeTaken *= damageMultiplier;
            base.ActivateAbility(character);

            if (chargesSpecial)
            {
                //carrega um pouco da barra de especial
            }
        }
    }
}
