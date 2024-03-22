using MyUtils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillButton : MonoBehaviour
{
    private Skill skill;
    public GameEvent gameEvent;
    public GameEvent showTarget;

    public void SetSkill(Skill skill)
    {
        this.skill = skill;
    }

    public void PassSkillInformation()
    {
        gameEvent.Raise(this, skill);
        showTarget.Raise(this, skill.targets);
    }
}
