using MyUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButtonPanels : MonoBehaviour
{
    //Set in inspector
    [SerializeField] private SkillButton[] skillButtons;
    public GameEvent restartText;

    //Get in code
    private BaseCharacter character;
    private List<Skill> skills;

    private void RestartButtons()
    {
        foreach (SkillButton button in skillButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void UpdateSkillButtonsSpecial()
    {
        RestartButtons();

        skills = character.GetSpecialSkillList();
        for(int i = 0; i < skills.Count; i++) 
        {
            skillButtons[i].gameObject.SetActive(true);

            skillButtons[i].SetSkill(skills[i]);
        }
    }

    public void UpdateSkillButtonsNormal()
    {
        RestartButtons();

        skills = character.GetNormalSkillList();
        for (int i = 0; i < skills.Count; i++)
        {
            skillButtons[i].gameObject.SetActive(true);

            skillButtons[i].SetSkill(skills[i]);
        }
    }

    public void ListenToSkillTurnStart(Component sender, object data)
    {
        if (data.GetType() != typeof(BaseCharacter))
        {
            Debug.LogError("Skill Panel trying to get skills from a non-character!", sender);
        }

        character = (BaseCharacter)data;
        RestartButtons();
        restartText.Raise(this, null);
    }
}
