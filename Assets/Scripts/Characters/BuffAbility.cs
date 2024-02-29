using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Abilities/BuffAbility", order = 2)]
public class BuffAbility : Ability
{
    public List<Stat> statList;
    public List<int> buffLifetime;

    public override void ActivateAbility(BaseCharacter character)
    {
        base.ActivateAbility(character);
        
        for(int i = 0; i < statList.Count; i++)
        {
            character.SetBuff(statList[i], buffLifetime[i]);
        }
    }
}