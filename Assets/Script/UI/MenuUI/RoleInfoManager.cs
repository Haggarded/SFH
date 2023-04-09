using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleInfoManager : MonoBehaviour
{
    public struct Info
    {
        public string InfoTitle;
        public string InfoValue;
        public string StyleTitle;
        public string StyleInfo;

    };
    public Info Enginer;
    public Info Sniper;
    public Info Rambo;
    public Info Tower;
    public int CurrentRole;
    // Start is called before the first frame update
    void Start()
    {
        DataInit();
    }
    public void changeInfo()
    {
        switch (CurrentRole)
        {
            case 0:
                {
                    GameObject.Find("RoleBGTitle").GetComponent<Text>().text = Enginer.InfoTitle;
                    GameObject.Find("RoleBG").GetComponent<Text>().text = Enginer.InfoValue;
                    GameObject.Find("StyleTitle").GetComponent<Text>().text = Enginer.StyleTitle;
                    GameObject.Find("StyleInfo").GetComponent<Text>().text = Enginer.StyleInfo;
                    break;
                }
            case 1:
                {
                    GameObject.Find("RoleBGTitle").GetComponent<Text>().text = Sniper.InfoTitle;
                    GameObject.Find("RoleBG").GetComponent<Text>().text = Sniper.InfoValue;
                    GameObject.Find("StyleTitle").GetComponent<Text>().text = Sniper.StyleTitle;
                    GameObject.Find("StyleInfo").GetComponent<Text>().text = Sniper.StyleInfo;
                    break;
                }
            case 2:
                {
                    GameObject.Find("RoleBGTitle").GetComponent<Text>().text = Rambo.InfoTitle;
                    GameObject.Find("RoleBG").GetComponent<Text>().text = Rambo.InfoValue;
                    GameObject.Find("StyleTitle").GetComponent<Text>().text = Rambo.StyleTitle;
                    GameObject.Find("StyleInfo").GetComponent<Text>().text = Rambo.StyleInfo;
                    break;
                }
            case 3:
                {
                    GameObject.Find("RoleBGTitle").GetComponent<Text>().text = Tower.InfoTitle;
                    GameObject.Find("RoleBG").GetComponent<Text>().text = Tower.InfoValue;
                    GameObject.Find("StyleTitle").GetComponent<Text>().text = Tower.StyleTitle;
                    GameObject.Find("StyleInfo").GetComponent<Text>().text = Tower.StyleInfo;
                    break;
                }
        }
    }
    private void DataInit()
    {
        Enginer = new Info
        {
            InfoTitle = "内森(NaThan)，工程兵",
            InfoValue = "33岁，代号工程师" + "\n" + "在军队服役的第二年，内森的鲁莽争强终于让他名誉扫地，最终被军队开除军籍，耻辱的离开了军队。不甘心的他开始了日复一日的艰苦训练，日常训练的同时磨平了他的锈迹，露出了其宝剑般的锋芒。凭借着自身过硬的战斗能力和技术能力，内森最终被小队接纳，成为小队的一员。",
            StyleTitle = "作战风格：中坚力量/战场支援",
            StyleInfo = "擅长使用中距离武器，他的招牌炮塔能在战场上为自己的团队提供强有力的支持。"

        };
        Sniper = new Info
        {
            InfoTitle = "冷锋，狙击手",
            InfoValue = "25岁" + "\n" + "作为战狼中队最年轻的狙击手，冷锋展现出了惊人的狙击天赋。为了追求理想，他申请加入了维和小队。作为一个活泼的年轻人，在进入小队初便与大伙打成一团。但当端起这把钢枪时，他的冷静和稳重会使他化身战场上的死神。",
            StyleTitle = "作战风格：远程狙击/战场刺杀",
            StyleInfo = "擅长使用中远距离武器，得益于高额的伤害和几乎没有的扩散他能给敌方带来毁灭性打击。"

        };
        Rambo = new Info
        {
            InfoTitle = "兰博(Rambo)，机枪手",
            InfoValue = "42岁" + "\n" + "作为外籍士兵，兰博和小队其他人员的关系从来没有合拍过，他与小队也没有任何从属关系。虽然凭借赫赫战功和过硬的战场支援技术，兰博进入小队已经多年，但谁都知道兰博从来只最看重钱",
            StyleTitle = "作战风格：重型武器/弹药支援",
            StyleInfo = "擅长使用高续航的重型武器，他的弹药支援会缓解战场的弹药紧缺问题。"

        };
        Tower = new Info
        {
            InfoTitle = "姓名不详,重甲兵",
            InfoValue = "年龄不详，代号“铁塔”" + "\n" + "这位神秘的战士在小队创立之初便已经加入了，他仅被派遣到最危险的任务里去，坚不可摧的重甲和骇人的力量使他获得了“铁塔”的称号，正如他的称号一样，在战斗中它将是敌人无法绕过的铁塔。",
            StyleTitle = "作战风格：人型坦克/重甲抗伤",
            StyleInfo = "擅长使用近距离杀伤武器，他特制的重型护甲可以提供超高的防护。"

        };


    }
    public void changeRole(int role)
    {
        CurrentRole = role;

    }
}
