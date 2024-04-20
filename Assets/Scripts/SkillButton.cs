using MyUtils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillButton : MonoBehaviour
{
    private Skill skill;
    public GameEvent skillSelected;
    public GameEvent showTarget;
    private TextMeshProUGUI textChild;

    public void SetSkill(Skill skill)
    {
        this.skill = skill;
        textChild = transform.GetComponentInChildren<TextMeshProUGUI>();
        textChild.text = skill.skillName;
    }

    public void PassSkillInformation()
    {
        skillSelected.Raise(this, skill);
        showTarget.Raise(this, skill.targets);
    }
}
