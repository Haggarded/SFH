using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "CreateNewMap")]
public class Map_SO : ScriptableObject
{
    public int level;
    public Vector2[] EnemyPoint;
    public Vector2 PlayerPoint;
    public GameObject EnemyPrefab;
    public GameObject PlayerPrefab;
    public string info;
    public string Mapname;
    public Sprite image;

}
