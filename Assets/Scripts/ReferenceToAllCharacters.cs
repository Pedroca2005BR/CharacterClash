using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName ="OnlyOne", menuName ="Pokedex")]
public class ReferenceToAllCharacters : ScriptableObject
{
    public List<GameObject> characterPrefabs;

    public GameObject GetCharacterByName(string name)
    {
        foreach (GameObject character in characterPrefabs)
        {
            if (character.GetComponent<BaseCharacter>().GetCharacterName() == name)
            {
                return character;
            }
        }

        Debug.LogError("Character Searched Does Not Exist!");
        return null;
    }
}
