using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<GameObject> ShopGrid;
    public List<Gun_SO> EngineerPool;
    public List<Gun_SO> SniperPool;
    public List<Gun_SO> RamboPool;
    public List<Gun_SO> TowerPool;
    public int CurrentRole = 0;
    [System.Serializable]
    public struct Goods
    {
        public Gun_SO gundata;
        public int cost;
    }
    [SerializeField]
    public List<Goods> SniperItem;
    public List<Goods> RamboItem;
    public List<Goods> EngineerItem;
    public List<Goods> TowerItem;
    public Goods currentGoods;
    public List<Goods> CurrentItem;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            ShopGrid.Add(child);
        }
        GenerateEngineerGoods();
        GenerateRamboGoods();
        GenerateSniperGoods();
        GenerateTowerGoods();
        CurrentItem = EngineerItem;
        ChanegGoodsData();
    }
    public void GenerateSniperGoods()
    {
        for (int i = 0; i < 8; i++)
        {
            Goods Item = new Goods
            {
                gundata = SniperPool[RandomIndex(0, SniperPool.Count)],
                cost = CalCost()
            };
            SniperItem.Add(Item);
        }
    }
    public void GenerateEngineerGoods()
    {
        for (int i = 0; i < 8; i++)
        {
            Goods Item = new Goods
            {
                gundata = EngineerPool[RandomIndex(0, EngineerPool.Count)],
                cost = CalCost()
            };
            EngineerItem.Add(Item);
        }
    }
    public void GenerateRamboGoods()
    {
        for (int i = 0; i < 8; i++)
        {
            Goods Item = new Goods
            {
                gundata = RamboPool[RandomIndex(0, RamboPool.Count)],
                cost = CalCost()
            };
            RamboItem.Add(Item);
        }
    }
    public void GenerateTowerGoods()
    {
        for (int i = 0; i < 8; i++)
        {
            Goods Item = new Goods
            {
                gundata = TowerPool[RandomIndex(0, TowerPool.Count)],
                cost = CalCost()
            };
            TowerItem.Add(Item);
        }
    }
    public void ChanegGoodsData()
    {
        for (int i = 0; i < CurrentItem.Count; i++)
        {
            ShopGrid[i].GetComponent<ShopGrid>().ChangeIMG(CurrentItem[i].gundata.GunPng);
            ShopGrid[i].GetComponent<ShopGrid>().Cost = CurrentItem[i].cost;
            ShopGrid[i].GetComponent<GetGunData>().GunData = CurrentItem[i].gundata;
        }
    }
    public void changeShop()
    {
        switch (CurrentRole)
        {
            case 0:
                {
                    CurrentItem = EngineerItem;
                    ChanegGoodsData();
                    break;
                }
            case 1:
                {
                    CurrentItem = SniperItem;
                    ChanegGoodsData(); break;
                }
            case 2:
                {
                    CurrentItem = RamboItem;
                    ChanegGoodsData(); break;
                }
            case 3:
                {
                    CurrentItem = TowerItem;
                    ChanegGoodsData(); break;
                }
        }
    }
    public int CalCost()
    {
        return UnityEngine.Random.Range(1, 1000);
    }
    public int RandomIndex(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }
    public Goods FindGoodsByData(Gun_SO gundata, int cost)
    {
        foreach (Goods item in CurrentItem)
        {
            if (item.cost == cost && item.gundata == gundata)
            {
                return item;
            }
        }
        Debug.Log("没找到");
        return currentGoods;
    }
    public void BuyGun()
    {
        GetSaveData saveData = GameObject.Find("Canvas").GetComponent<GetSaveData>();
        if (saveData.Gold >= currentGoods.cost)
        {
            saveData.jobSave[CurrentRole].GunStore.Add(currentGoods.gundata);
            Debug.Log(1);
        }
        CurrentItem.Remove(currentGoods);
    }
}

