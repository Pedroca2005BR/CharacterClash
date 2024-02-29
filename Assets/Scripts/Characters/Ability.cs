using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtils;

public enum WhatJustHappened
{
    OnAttack,
    OnDefend,
    OnStatusApplied,
    OnAllyDeath,
    OnEnemyDeath,
    OnSelfDeath,
    OnHealed,
    OnStartOfBattle
}

public class Ability : ScriptableObject
{
    public GameEvent OnAbilityUsed;
    public WhatJustHappened timeOfActivation;

    [Header("UI Things")]
    public string abilityName;
    //talvez eu bote outras informacoes uteis aqui

    [Header("Miscellaneous")]
    public int timesItCanHappen = int.MaxValue;
    [SerializeField, Range(0, 100)] private int chance = 100;

    //Quando a habilidade for ativada, a UI vai escutar e fazer seu papel. Para isso, precisa saber quem
    //ativou o evento (character) e o que deve fazer (UI things)
    public virtual void ActivateAbility(BaseCharacter character)
    {
        if (timesItCanHappen == 0 || chance < Random.Range(0, 100)) { return; }

        OnAbilityUsed.Raise(character, this);
        timesItCanHappen--;
    }
}
