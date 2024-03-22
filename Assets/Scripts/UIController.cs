using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void UpdateSkillSelection(Component character, object data)
    {
        if (character.GetType() != typeof(BaseCharacter))
        {
            Debug.LogError("Trying to get skills from a non-character!");
            return;
        }
    }
}
