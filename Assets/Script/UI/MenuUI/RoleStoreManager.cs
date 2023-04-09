using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleStoreManager : MonoBehaviour
{
    public List<GameObject> ChildList;
    public GetJobData CurrentJobData;
    public int CurrentRole = 0;
    public GameObject EquipGird;
    private void Start()
    {

    }
    public void Init()
    {
        CurrentRole = GameObject.Find("RoleSetting_Main").GetComponent<RoleSettingManager>().CurrentRole;
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            ChildList.Add(child);
        }
        CurrentJobData.jobData = GameObject.Find("Canvas").GetComponent<GetSaveData>().jobSave[CurrentRole];
        ChangeButtonImgFromData();
    }
    public void ChangeButtonImgFromData()
    {
        if (ChildList.Count == 0)
        {
            Init();

        }
        for (int i = 0; i < CurrentJobData.GunStore.Count; i++)
        {
            ChildList[i].GetComponentInChildren<Button>().image.sprite = CurrentJobData.GunStore[i].GunPng;
            ChildList[i].GetComponentInChildren<Button>().image.color = new Color(1, 1, 1, 1);
            ChildList[i].GetComponentInChildren<Button>().GetComponent<GetGunData>().GunData = CurrentJobData.GunStore[i];
        }

    }
    public void CleanButtonSprite()
    {
        for (int i = 0; i < ChildList.Count; i++)
        {
            ChildList[i].GetComponentInChildren<Button>().image.sprite = null;
            ChildList[i].GetComponentInChildren<Button>().image.color = new Color(1, 1, 1, 0);
            ChildList[i].GetComponentInChildren<Button>().GetComponent<GetGunData>().GunData = null;
        }
    }
    public void ChangeWeaponData()
    {
        CleanButtonSprite();
        CurrentRole = GameObject.Find("RoleSetting_Main").GetComponent<RoleSettingManager>().CurrentRole;
        CurrentJobData.jobData = GameObject.Find("Canvas").GetComponent<GetSaveData>().jobSave[CurrentRole];
        ChangeButtonImgFromData();

    }
    public void changeEquipButton()
    {
        foreach (GameObject button in ChildList)
        {
            Color color = button.GetComponentInChildren<Text>().color;
            if (button == EquipGird)
            {
                button.GetComponentInChildren<Text>().color = new Color(color.r, color.g, color.b, 1);
            }
            else
            { button.GetComponentInChildren<Text>().color = new Color(color.r, color.g, color.b, 0); }
        }
    }
}
