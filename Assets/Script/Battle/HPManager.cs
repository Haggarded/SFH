using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public GetRoleData RoleData;
    public GetJobData jobData;
    public bool isdead;
    public float maxHP;
    public float currentHP;
    public float maxArmor;
    public float currentArmor;
    public SoundManager soundManager;
    public UIManager uIManager;
    // Start is called before the first frame update
    public Slider HPBar;
    public Slider ArmorBar;
    public void ChangeHPBar()
    {
        if (currentHP == maxHP)
        {
            ArmorBar.value = 1;
            HPBar.value = currentHP / (currentHP + currentArmor);
        }
        else if (currentArmor > 0)
        {
            HPBar.value = 1;
            ArmorBar.value = currentArmor / (currentArmor + currentHP);
        }
        else if (currentArmor <= 0)
        {
            HPBar.value = currentHP / maxHP;
            ArmorBar.value = currentHP / maxHP;

        }
        if (gameObject.tag == "Player")
        {
            uIManager.ChangeHP(currentHP, currentArmor);
        }
    }
    void Start()
    {
        RoleData = this.gameObject.GetComponent<GetRoleData>();
        maxHP = RoleData.MaxHP;
        maxArmor = RoleData.MaxArmor;
        currentArmor = maxHP;
        currentHP = maxHP;
        ChangeHPBar();
        soundManager = GetComponent<SoundManager>();
    }
    public void Dead()
    {
        if (!isdead)
        {
            isdead = true;
            soundManager.PlayDead();
            Destroy(this.gameObject, 2);
        }
    }
    public int CalRoleLevel(int exp)
    {
        int exprience = exp;
        int level = 1;
        int requireExp = 100;
        while (exprience > requireExp)
        {
            exprience -= requireExp;
            requireExp += 100;
        }
        return level;
    }
    public void CalDataByLevel(int level, int job, string valuetype)
    {
        switch (valuetype)
        {

        }

    }
}
