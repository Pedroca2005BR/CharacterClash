using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTransformation", menuName = "Skills/Transformation", order = 1)]
public class TransformationSkill : Skill
{
    [Header("Transformation Specifics")]
    public int duration;
    public GameObject newModel;
}
