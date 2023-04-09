using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSaveData : MonoBehaviour
{
    public Save_SO SaveData;
    public int Gold
    {
        get
        {
            if (SaveData != null)
                return SaveData.Gold;
            else return 0;
        }
        set
        {
            SaveData.Gold = value;
        }
    }
    public List<Job_SO> jobSave
    {
        get
        {
            if (SaveData != null)
                return SaveData.jobSave;
            else return null;
        }
        set
        {
            SaveData.jobSave = value;
        }
    }
    public int CurrentRole
    {
        get
        {
            if (SaveData != null)
                return SaveData.CurrentRole;
            else return 0;
        }
        set
        {
            SaveData.CurrentRole = value;
        }
    }

}
