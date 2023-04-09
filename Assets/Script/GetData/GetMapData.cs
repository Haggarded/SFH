using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMapData : MonoBehaviour
{
    public Map_SO MapData;
    public int level
    {
        get
        {
            if (MapData != null)
                return MapData.level;
            else return 0;
        }
    }
    public Vector2[] EnemyPoint
    {
        get
        {
            if (MapData != null)
                return MapData.EnemyPoint;
            else return null;
        }
    }
    public GameObject EnemyPrefab
    {
        get
        {
            if (MapData != null)
                return MapData.EnemyPrefab;
            else return null;
        }
    }
    public GameObject PlayerPrefab
    {

        get
        {
            if (MapData != null)
                return MapData.PlayerPrefab;
            else return null;
        }

    }
    public Sprite image
    {
        get
        {
            if (MapData != null)
                return MapData.image;
            else return null;
        }
    }
    public string info
    {
        get
        {
            if (MapData != null)
                return MapData.info;
            else return null;
        }
    }
    public string Mapname
    {
        get
        {
            if (MapData != null)
                return MapData.Mapname;
            else return null;
        }
    }
    public Vector2 PlayerPoint
    {
        get
        {
            if (MapData != null)
                return MapData.PlayerPoint;
            else return Vector2.zero;
        }
    }
}
