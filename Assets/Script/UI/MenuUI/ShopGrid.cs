using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopGrid : MonoBehaviour
{
    public Image GunPng;
    public GetGunData GunData;
    public int Cost;
    private void Start()
    {
        GunData = GetComponent<GetGunData>();
    }
    public void ShowThisGun()
    {
        GameObject.Find("DamageValue").GetComponent<Text>().text = GunData.attack.ToString();
        GameObject.Find("RecoilValue").GetComponent<Text>().text = GunData.recoil.ToString();
        GameObject.Find("SpeedValue").GetComponent<Text>().text = GunData.speed.ToString();
        GameObject.Find("ContainValue").GetComponent<Text>().text = GunData.ammoCap.ToString();
        GameObject.Find("OffsetValue").GetComponent<Text>().text = GunData.originOffset.ToString();
        GameObject.Find("CostValue").GetComponent<Text>().text = Cost.ToString();
        GameObject.Find("GunShowImage").GetComponent<Image>().sprite = GunData.GunPng;
    }
    public void ChangeIMG(Sprite image)
    {
        GunPng.sprite = image;
    }
    public void ChangeCurrentGun()
    {
        ShopManager shopManager = GameObject.Find("ShopGrid").GetComponent<ShopManager>();
        shopManager.currentGoods =(shopManager.FindGoodsByData(GunData.GunData, Cost));
    }
}
