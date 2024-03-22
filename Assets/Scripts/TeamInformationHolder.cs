using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewInfoHolder", menuName ="TeamInformationHolder")]
public class TeamInformationHolder : ScriptableObject
{
    public List<GameObject> characterPrefabs;
    public List<Transform> characterLocations;

    public void ResetInformation()
    {
        characterLocations.Clear();
        characterPrefabs.Clear();
    }

    public void AddCharacter(GameObject character)
    {
        characterPrefabs.Add(character);
    }

    public List<BaseCharacter> SpawnCharacters(GameObject gameManager)
    {
        List<BaseCharacter> references = new List<BaseCharacter>();

        for(int i = 0; i < characterPrefabs.Count; i++)
        {
            GameObject character = Instantiate(characterPrefabs[i], characterLocations[i].position, Quaternion.identity, gameManager.transform);
            BaseCharacter charBase = character.GetComponent<BaseCharacter>();

            if (charBase == null)
            {
                Debug.LogError("Trying to Spawn a non-Character! Number: " + (i+1).ToString());
                continue;
            }

            charBase.SetTeam(WhatTeam(i));
            charBase.SetFrontRow(WhatRow(i));

            references.Add(charBase);
        }

        return references;
    }

    public BaseCharacter GetCharacterByPosition(int pos)
    {
        return characterPrefabs[pos].GetComponent<BaseCharacter>();
    }

    public bool WhatTeam(int i)
    {
        if (i < characterPrefabs.Count/2)
        {
            return true;
        }
        return false;
    }

    public bool WhatRow(int i)
    {
        if (i >= characterPrefabs.Count/2)
        {
            i -= characterPrefabs.Count/2;
        }

        if (i%2 == 0)
        {
            return true;
        }
        return false;
    }
}
