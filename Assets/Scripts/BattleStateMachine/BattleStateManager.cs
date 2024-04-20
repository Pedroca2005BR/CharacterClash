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
    public Skill currentSkill;
    public int[] currentTarget;

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




    //#######################################################################################
    //Game Event Listeners

    public void ListenToMove(Component sender, object data)
    {
        if (data.GetType() == typeof(Skill))
        {
            currentSkill = (Skill)data;
        }
    }

    public void ListenToTarget(Component sender, object data)
    {
        if (data.GetType() != typeof(int[]))
        {
            Debug.Log("Battle Manager trying to get Targets, but Failing!");
        }

        int[] newData = (int[])data;

        currentTarget = new int[newData.Length];
        for (int i = 0; i < newData.Length; i++)
        {
            currentTarget[i] = newData[i];
        }
    }
}
