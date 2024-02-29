using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtils;

public class BaseCharacter : MonoBehaviour
{
    //Identification
    [SerializeField] private string characterName;
    private bool isBlueTeam;
    private bool isFrontRow;

    //Stats
    [Header("RPG Stats")]
    [SerializeField] private int maxHealth;
    public GeneralBarSystem healthSystem;
    [SerializeField] private int maxSpecial;
    public GeneralBarSystem specialSystem;
    public Stat physicalAttack;
    public Stat physicalDefense;
    public Stat magicAttack;
    public Stat magicDefense;
    public Stat precision;
    public Stat evasion;

    //Events
    [Header("Events")]
    public GameEvent OnDeathEvent;

    //Skills
    [SerializeField] private List<Skill> normalSkillList;
    [SerializeField] private List<Skill> specialSkillList;
    [SerializeField] private Skill Ultimate;

    //Abilities
    [SerializeField] private List<Ability> abilityList;

    //In game usage
    public Skill skillReceived { get; private set; }
    public int damageToBeTaken;

    private void Awake()
    {
        healthSystem = new GeneralBarSystem(maxHealth);
        specialSystem = new GeneralBarSystem(maxSpecial);
        physicalAttack.Setup();
        physicalDefense.Setup();
        magicAttack.Setup();
        magicDefense.Setup();
        precision.Setup();
        evasion.Setup();
    }

    //StatsMethods
    public void TurnUpdateStats()
    {
        physicalAttack.LifetimeDown();
        physicalDefense.LifetimeDown();
        magicAttack.LifetimeDown();
        magicDefense.LifetimeDown();
        precision.LifetimeDown();
        evasion.LifetimeDown();
    }

    public void SetBuff(Stat stat, int lifetime)
    {
        switch(stat.name)
        {
            case "physicalAttack":
                physicalAttack.ApplyBuff(stat, lifetime);
                break;
            case "magicAttack":
                magicAttack.ApplyBuff(stat, lifetime);
                break;
            case "physicalDefense":
                physicalDefense.ApplyBuff(stat, lifetime);
                break;
            case "magicDefense":
                magicDefense.ApplyBuff(stat, lifetime);
                break;
            case "precision":
                precision.ApplyBuff(stat, lifetime);
                break;
            case "evasion":
                evasion.ApplyBuff(stat, lifetime);
                break;

        }
    }

    //AbilityMethods
    public void CheckAbilities(WhatJustHappened whatIsHappening)
    {
        foreach(Ability ability in abilityList)
        {
            if (ability.timeOfActivation == whatIsHappening)
            {
                ability.ActivateAbility(this);
            }
        }
    }

    //SkillMethods
    public List<Skill> GetSpecialSkillList()
    {
        return specialSkillList;
    }

    public List<Skill> GetNormalSkillList()
    {
        return normalSkillList;
    }

    //IdentificationMethods
    public bool IsBlueTeam()
    {
        return isBlueTeam;
    }

    public void SetTeam(bool team)
    {
        isBlueTeam = team;
    }

    public bool IsFrontRow()
    {
        return isFrontRow;
    }

    public void SetFrontRow(bool row)
    {
        isFrontRow = row;
    }

    public string GetCharacterName()
    {
        return characterName;
    }

    //EventResponses
    public void OnCharacterDeath(Component component, object data)
    {
        if ((bool)data == IsBlueTeam() && component.gameObject != gameObject)
        {
            CheckAbilities(WhatJustHappened.OnAllyDeath);
        }
        else if((bool)data != IsBlueTeam())
        {
            CheckAbilities(WhatJustHappened.OnEnemyDeath);
        }
    }

    public void OnStartOfBattle(Component component, object data)
    {
        Debug.Log(characterName + " heard that a Battle has started!");
        CheckAbilities(WhatJustHappened.OnStartOfBattle);
    }
}
