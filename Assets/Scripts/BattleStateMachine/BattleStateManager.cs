using MyUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateManager : MonoBehaviour
{
    //States
    BaseBattleState currentState;
    public AttackResponseBattleState attackResponseBattleState = new AttackResponseBattleState();
    public CharAttackBattleState charAttackBattleState = new CharAttackBattleState();
    public TurnChangeBattleState turnChangeBattleState = new TurnChangeBattleState();
    public StartOfBattleBattleState startOfBattleBattleState = new StartOfBattleBattleState();
    public EndOfBattleBattleState endOfBattleBattleState = new EndOfBattleBattleState();
    public SkillSelectionBattleState skillSelectionBattleState = new SkillSelectionBattleState();
    public TargetSelectionBattleState targetSelectionBattleState = new TargetSelectionBattleState();

    //Events
    [Header("Events")]
    public GameEvent OnStartOfBattle;
    public GameEvent OnSkillSelectionStart;

    //necessaryInformation
    [Header("Information")]
    public TeamInformationHolder teamInformationHolder;
    public int currentTurn;

    private void Start()
    {
        currentState = startOfBattleBattleState;
        currentTurn = 0;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseBattleState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
