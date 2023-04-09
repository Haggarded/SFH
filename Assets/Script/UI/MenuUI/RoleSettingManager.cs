using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleSettingManager : MonoBehaviour
{
    public int CurrentRole = 0;
    public GameObject Info;
    public GameObject store;
    public GameObject skill;
    public GameObject shop;
    public GameObject[] MenuList;
    private void Start()
    {
        MenuList = new GameObject[]
        {
            Info,
            store,
            skill,
            shop
        };
    }
    public void ChangeToEnginer()
    {
        CurrentRole = 0;
        GameObject.Find("Canvas").GetComponent<GetSaveData>().CurrentRole = 0;
        ChangeData();
        ChangeStore();
        ChangeShop();
    }
    public void ChangeToSniper()
    {
        CurrentRole = 1;
        GameObject.Find("Canvas").GetComponent<GetSaveData>().CurrentRole = 1;
        ChangeData();
        ChangeStore();
        ChangeShop();
    }
    public void ChangeToRambo()
    {
        CurrentRole = 2;
        GameObject.Find("Canvas").GetComponent<GetSaveData>().CurrentRole = 2;
        ChangeData();
        ChangeStore();
        ChangeShop();
    }
    public void ChangeToTower()
    {
        CurrentRole = 3;
        GameObject.Find("Canvas").GetComponent<GetSaveData>().CurrentRole = 3;
        ChangeData();
        ChangeStore();
        ChangeShop();
    }
    public void ShowInfo()
    {
        ShowPanel(Info);
        ChangeData();

    }
    public void ShowStore()
    {
        ShowPanel(store);
        ChangeStore();

    }
    public void ShowSkill()
    {
        ShowPanel(skill);

    }
    public void ShowShop()
    {
        ShowPanel(shop);
        ChangeShop();
    }
    void ShowPanel(GameObject panelToShow)
    {
        foreach (GameObject panel in MenuList)
        {
            panel.SetActive(panel == panelToShow);
        }
    }
    public void ChangeData()
    {
        Info.GetComponent<RoleInfoManager>().changeRole(CurrentRole);
        if (Info.activeSelf)
        {
            Info.GetComponent<RoleInfoManager>().changeInfo();
        }

    }
    public void ChangeStore()
    {
        store.GetComponentInChildren<RoleStoreManager>().CurrentRole = CurrentRole;
        if (store.activeSelf)
        {
            store.GetComponentInChildren<RoleStoreManager>().ChangeWeaponData();
        }
    }
    public void ChangeShop()
    {
        shop.GetComponentInChildren<ShopManager>().CurrentRole = CurrentRole;
        if (shop.activeSelf)
        {
            shop.GetComponentInChildren<ShopManager>().changeShop();
        }
    }
}