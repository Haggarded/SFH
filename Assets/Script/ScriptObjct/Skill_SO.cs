using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateNewSkill", fileName = "Skill")]
public class Skill_SO : ScriptableObject
{
    public int SkillID;
    public bool isActive;
}
