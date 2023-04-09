using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIEffects;


public class MenuUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void PointIN()
    {
        UITransitionEffect transformEffect = GetComponent<UITransitionEffect>();
        transformEffect.Show(false);
    }
    public void PointOut()
    {
        UITransitionEffect transformEffect = GetComponent<UITransitionEffect>();
        transformEffect.Hide(false);
    }
    public void Gradually()
    {
        UITransitionEffect transformEffect = GetComponent<UITransitionEffect>();
        transformEffect.Hide(false);
        Destroy(this.gameObject, 1);
    }
    public void Fade()
    {
        UITransitionEffect transformEffect = GetComponent<UITransitionEffect>();
        transformEffect.Show(false);
    }
    public void streamerIN()
    {
        UITransitionEffect transformEffect = GetComponent<UITransitionEffect>();
        transformEffect.Show(false);

    }
    public void streamerOut()
    {
        UITransitionEffect transformEffect = GetComponent<UITransitionEffect>();
        transformEffect.Hide(false);
    }
    public void ChangeInfo()
    {
        GetMapData mapData = GetComponent<GetMapData>();
        int level = mapData.level;
        string info = mapData.info;
        Sprite Datasprite = mapData.image;
        GameObject.Find("LevelInfo").GetComponent<Text>().text = level.ToString();
        GameObject.Find("MissionInfo").GetComponent<Text>().text = info;
        GameObject.Find("BattleView").GetComponent<Image>().sprite = Datasprite;
        transform.root.gameObject.GetComponent<CanvasManager>().sence = mapData.level;
    }
    public void ChangeInfoToShop()
    {
        GameObject.Find("IconIn").GetComponent<Text>().text = "Shop";
    }
    public void ChangeInfoToInfo()
    {
        GameObject.Find("IconIn").GetComponent<Text>().text = "Information";
    }
    public void ChangeInfoToStore()
    {
        GameObject.Find("IconIn").GetComponent<Text>().text = "Store";
    }
    public void ChangeInfoToSkill()
    {
        GameObject.Find("IconIn").GetComponent<Text>().text = "Skill";
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
