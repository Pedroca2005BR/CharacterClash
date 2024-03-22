using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] childrenTexts;

    public void UpdateText(Component sender, object data)
    {
        //The SkillButtonPanels will raise the event with null data so to clean the text
        if (data == null)
        {
            foreach (TextMeshProUGUI child in childrenTexts)
            {
                child.text = "";
            }
        }

        //The Buttons however will send a skill with data
        if (data.GetType() == typeof(Skill))
        {
            Skill newData = (Skill)data;

            //Name
            childrenTexts[0].text = newData.skillName;
            //Power
            childrenTexts[1].text = newData.baseDamage.ToString();
            //Accuracy
            childrenTexts[2].text = newData.baseAccuracy.ToString() + "%";
            //SuperType
            childrenTexts[3].text = newData.superType.ToString();
            //SubTypes
            childrenTexts[4].text = "";
            foreach (SkillSubType subType in newData.subTypes)
            {
                if (childrenTexts[4].text != "") childrenTexts[4].text += "/";
                childrenTexts[4].text += subType.ToString();
            }
            //Description
            childrenTexts[5].text = newData.description;
        }
        else
        {
            Debug.LogError("TextUpdater trying to acces non-Skill data!", sender);
        }
    }
}
