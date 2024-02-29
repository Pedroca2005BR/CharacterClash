using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOfBattleBattleState : BaseBattleState
{
    public override void EnterState(BattleStateManager context)
    {
        Debug.Log("Start of Battle!");
        context.OnStartOfBattle.Raise(context, null);
    }

    public override void UpdateState(BattleStateManager context)
    {
        throw new System.NotImplementedException();
    }
}
