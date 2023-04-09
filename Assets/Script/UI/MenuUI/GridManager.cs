using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public void ChanegCurrentEquip()
    {
        GameObject gameObject = GameObject.Find("WeaponStore");
        Debug.Log(GetComponent<GetGunData>().GunData);
        gameObject.GetComponent<GetJobData>().EquipGun = GetComponent<GetGunData>().GunData;
        gameObject.GetComponent<RoleStoreManager>().EquipGird = transform.parent.gameObject;
    }
}
