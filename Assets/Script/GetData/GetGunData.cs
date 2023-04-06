using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGunData : MonoBehaviour
{
    public Gun_SO GunData;

    public float attack
    {
        get
        {
            if (GunData != null)
                return GunData.attack;
            else return 0;
        }
        set
        {
            GunData.attack = value;
        }
    }
    public int speed
    {
        get
        {
            if (GunData != null)
                return GunData.speed;
            else return 0;
        }
        set
        {
            GunData.speed = value;
        }
    }
    public float originOffset
    {
        get
        {
            if (GunData != null)
                return GunData.originOffset;
            else return 0;
        }
        set
        {
            GunData.originOffset = value;
        }
    }
    public int ammoCap
    {
        get
        {
            if (GunData != null)
                return GunData.ammoCap;
            else return 0;
        }
        set
        {
            GunData.ammoCap = value;
        }
    }
    public int reserveAmmo
    {
        get
        {
            if (GunData != null)
                return GunData.reserveAmmo;
            else return 0;
        }
        set
        {
            GunData.reserveAmmo = value;
        }
    }
    public float reloadSpeed
    {
        get
        {
            if (GunData != null)
                return GunData.reloadSpeed;
            else return 0;
        }
        set
        {
            GunData.reloadSpeed = value;
        }
    }
    public float recoil
    {
        get
        {
            if (GunData != null)
                return GunData.recoil;
            else return 0;
        }
        set
        {
            GunData.recoil = value;
        }
    }
    public float recoilRecover
    {
        get
        {
            if (GunData != null)
                return GunData.recoilRecover;
            else return 0;
        }
        set
        {
            GunData.recoilRecover = value;
        }
    }
    public int fadeDistance
    {
        get
        {
            if (GunData != null)
                return GunData.fadeDistance;
            else return 0;
        }
        set
        {
            GunData.fadeDistance = value;
        }
    }
    public int bulletNumber
    {
        get
        {
            if (GunData != null)
                return GunData.bulletNumber;
            else return 0;
        }
        set
        {
            GunData.bulletNumber = value;
        }
    }
    public Sprite GunPng
    {
        get
        {
            if (GunData != null)
                return GunData.GunPng;
            else return null;
        }
        set
        {
            GunData.GunPng = value;
        }
    }
    public Vector2 L_handPos
    {
        get
        {
            if (GunData != null)
                return GunData.L_handPos;
            else return new Vector2(0, 0);
        }
        set
        {
            GunData.L_handPos = value;
        }
    }
    public Vector2 R_handPos
    {
        get
        {
            if (GunData != null)
                return GunData.R_handPos;
            else return new Vector2(0, 0);
        }
        set
        {
            GunData.R_handPos = value;
        }
    }
    public Vector2 GunMuzzlePos
    {
        get
        {
            if (GunData != null)
                return GunData.GunMuzzlePos;
            else return new Vector2(0, 0);
        }
        set
        {
            GunData.GunMuzzlePos = value;
        }
    }
    public Vector2 PngOffset
    {
        get
        {
            if (GunData != null)
                return GunData.PngOffset;
            else return new Vector2(0, 0);
        }
        set
        {
            GunData.PngOffset = value;
        }
    }
    public string audioSrc
    {
        get
        {
            if (GunData != null)
                return GunData.audioSrc;
            else return null;
        }
        set
        {
            GunData.audioSrc = value;
        }
    }

}
