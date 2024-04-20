using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillSuperType
{
    Physical,
    Magic,
    Status
}

public enum SkillSubType
{
    Lightning,
    Poison,
    Slashing,
    Crushing,
    Piercing,
}

public enum TargetType
{
    FrontRow,
    BackRow,
    Ally,
    Self,
    AllEnemies,
    AllAllies
}

public enum StatusEffect
{
    Paralysis,
    Poison,
    Bleeding,
    Fast,
    Fury,
    BungeeGum
}

[CreateAssetMenu(fileName="NewSkill", menuName ="Skills/SkillBasic", order = 1)]
public class Skill : ScriptableObject
{
    public string skillName;
    [Header("Stats")]
    public int baseDamage;
    public int baseAccuracy;
    public int specialCost;

    //so tem um super tipo, mas pode ter varios subtipos
    [Header("Typing")]
    public SkillSuperType superType;
    public List<SkillSubType> subTypes;

    //Tipos possiveis de alvo e se pode acertar mais de um
    [Header("Targets")]
    public List<TargetType> targets;
    public bool isMultiTarget;

    [Header("Effects")]
    public List<StatusEffect> statusEffects;
    public List<Stat> statsBuffed;
    public List<int> buffsLifetime;

    [Header("Description")]
    public string description;
}
