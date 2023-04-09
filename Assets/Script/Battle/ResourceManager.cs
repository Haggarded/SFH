using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public EventManager eventManager;
    public GameManager gameManager;
    public GetSaveData save;
    public void Start()
    {
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        save = GetComponent<GetSaveData>();
        eventManager.BindEvent("Dead", changeMoney);

    }
    public void changeMoney()
    {
        int level = gameManager.mapData.level;
        int money = CalMoney(level);
        int exp = CalEXP(level);
        Debug.Log(exp);
        save.Gold = money + save.Gold;
        GetComponent<GetJobData>().exprience += exp;
    }
    public int CalMoney(int level)
    {
        int money = 10 * (level + 1);
        return money;

    }
    public int CalEXP(int level)
    {
        int exp = 10 * (level + 1);
        return exp;

    }
}
