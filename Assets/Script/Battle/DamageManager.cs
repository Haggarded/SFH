using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    //传入角色和受击部?
    public void Damage(float attack, GameObject defener, GameObject targetPlace)
    {
        HPManager hPManager = defener.GetComponent<HPManager>();
        float dam = CalDamage(attack, targetPlace.tag);
        float Difference = hPManager.currentArmor - dam;
        //有护甲减护甲
        if (Difference >= 0)
        {
            hPManager.currentArmor = Difference;
        }
        else
        {
            hPManager.currentArmor = 0;
            hPManager.currentHP += Difference;
        }
        hPManager.ChangeHPBar();
        if (hPManager.currentHP <= 0)
        {
            hPManager.Dead();
        }
    }
    public GameObject FindGameObject(GameObject RolePlace)
    {
        GameObject role = RolePlace.transform.root.gameObject;
        return role;
    }
    float CalDamage(float attack, string tag)
    {
        float damage = attack;
        switch (tag)
        {
            case "Head":
                damage = damage * 2;
                break;
            case "Body":
                break;
            case "Limbs":
                damage = damage * 0.5f;
                break;
        }
        return damage;
    }
}
