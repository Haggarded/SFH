using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetJobData : MonoBehaviour
{
    public Job_SO jobData;
    public int OriginHP
    {
        get
        {
            if (jobData != null)
                return jobData.OriginHP;
            else return 0;
        }
        set
        {
            jobData.OriginHP = value;
        }
    }
    public int job
    {
        get
        {
            if (jobData != null)
                return jobData.job;
            else return 0;
        }
    }
    public int exprience
    {
        get
        {
            if (jobData != null)
                return jobData.exprience;
            else return 0;
        }
        set
        {
            jobData.exprience = value;
        }
    }
    public int HPGrowth
    {
        get
        {
            if (jobData != null)
                return jobData.HPGrowth;
            else return 0;
        }
        set
        {
            jobData.HPGrowth = value;
        }
    }
    public float originSpeed
    {
        get
        {
            if (jobData != null)
                return jobData.originSpeed;
            else return 0;
        }
        set
        {
            jobData.originSpeed = value;
        }
    }
    public float SpeedGrowth
    {
        get
        {
            if (jobData != null)
                return jobData.SpeedGrowth;
            else return 0;
        }
        set
        {
            jobData.SpeedGrowth = value;
        }
    }
    public List<Gun_SO> GunStore
    {
        get
        {
            if (jobData != null)
                return jobData.GunStore;
            else return null;
        }
        set
        { jobData.GunStore = value; }
    }
    public Gun_SO EquipGun
    {
        get
        {
            if (jobData != null)
                return jobData.EquipGun;
            else return null;
        }
        set
        { jobData.EquipGun = value; }
    }

}
