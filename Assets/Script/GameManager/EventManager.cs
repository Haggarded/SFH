using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public delegate void EventHandler();
    public UnityEvent GameStart;
    public UnityEvent Dead;
    public UnityEvent GameOver;
    void Awake()
    {
        GameStart.AddListener(HASgetevent);
    }
    void Start()
    {

    }
    void Update()
    {

    }
    void HASgetevent()
    {
        Debug.Log("游戏开始");
    }
    public void OutGameStart()
    {
        GameStart.Invoke();
    }
    public void OutDead()
    {
        Dead.Invoke();
    }
    public void OutGameOver()
    {
        GameOver.Invoke();
    }
    public void BindEvent(string eventName, UnityAction function)
    {
        switch (eventName)
        {
            case "GameOver":
                {
                    GameOver.AddListener(function);
                    break;
                }
            case "Dead":
                {
                    Dead.AddListener(function);
                    break;
                }
            case "GameStart":
                {
                    GameStart.AddListener(function);
                    break;
                }
        }

    }
}
