using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelectionBattleState : BaseBattleState
{
    BaseCharacter character;

    public override void EnterState(BattleStateManager context)
    {
        character = context.teamInformationHolder.GetCharacterByPosition(context.currentTurn);
        context.OnSkillSelectionStart.Raise(context, character);
    }

    public override void UpdateState(BattleStateManager context)
    {
        
    }
}
