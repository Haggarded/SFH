using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public EventManager eventManager;
    public GetMapData mapData;
    public int enemyCount;
    public GetSaveData SaveData;
    public void Start()
    {
        eventManager.BindEvent("GameStart", CreateEnemy);
        eventManager.BindEvent("GameStart", CreatePlayer);
        eventManager.BindEvent("Dead", IsGameOver);
        eventManager.OutGameStart();
    }
    public void IsGameOver()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(0);
        }
    }
    public void CreateEnemy()
    {
        for (int i = 0; i < mapData.EnemyPoint.Length; i++)
        {
            Instantiate(mapData.EnemyPrefab, mapData.EnemyPoint[i], Quaternion.identity);
            enemyCount++;
        }

    }
    public void CreatePlayer()
    {
        GameObject Player = Instantiate(mapData.PlayerPrefab, mapData.PlayerPoint, Quaternion.identity);
        GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = Player.transform;
        Player.name = "Player";
        Player.GetComponent<GetJobData>().jobData = SaveData.jobSave[SaveData.CurrentRole];
    }
}
