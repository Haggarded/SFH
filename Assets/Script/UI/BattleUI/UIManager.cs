using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text HP;
    public Text Armor;
    public Text GunName;
    public Text Ammo;
    public Text R_Ammo;
    public void ChangeHP(float HPValue, float ArmorValue)
    {
        HP.text = HPValue.ToString();
        Armor.text = ArmorValue.ToString();

    }
    public void ChangeAmmo(int AmmoValue, int R_ammoValue)
    {
        Ammo.text = AmmoValue.ToString();
        R_Ammo.text = R_ammoValue.ToString();
    }
    public void ChangeGunName(string name)
    {
        GunName.text = name;

    }
}
