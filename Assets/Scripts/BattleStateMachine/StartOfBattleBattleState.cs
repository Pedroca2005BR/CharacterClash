using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOfBattleBattleState : BaseBattleState
{
    float smallCounter;

    public override void EnterState(BattleStateManager context)
    {
        Debug.Log("Start of Battle!");
        context.teamInformationHolder.SpawnCharacters(context.gameObject);
        smallCounter = 2.5f;
    }

    public override void UpdateState(BattleStateManager context)
    {
        smallCounter -= Time.deltaTime;
        if (smallCounter <= 0)
        {
            context.OnStartOfBattle.Raise(context, null);
            context.SwitchState(context.skillSelectionBattleState);
        }
    }
}
