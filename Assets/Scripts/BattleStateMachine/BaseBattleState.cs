
using UnityEngine;

public abstract class BaseBattleState
{
    public abstract void EnterState(BattleStateManager context);

    public abstract void UpdateState(BattleStateManager context);
}
