using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRoleData : MonoBehaviour
{
    public Character_SO characterData;
    public int MaxHP
    {
        get
        {
            if (characterData != null)
                return characterData.MaxHP;
            else return 0;
        }
        set
        {
            characterData.MaxHP = value;
        }
    }
    public int MaxArmor
    {
        get
        {
            if (characterData != null)
                return characterData.MaxArmor;
            else return 0;
        }
        set
        {
            characterData.MaxArmor = value;
        }
    }
    public float speed
    {
        get
        {
            if (characterData != null)
                return characterData.speed;
            else return 0;
        }
        set
        {
            characterData.speed = value;
        }
    }
}
