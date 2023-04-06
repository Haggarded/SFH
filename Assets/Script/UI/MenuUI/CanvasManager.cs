using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject RoleSettting;
    public GameObject MainMenu;
    public GameObject SinglePlayer;
    public GameObject MultPlayer;
    public GameObject Setting;
    public GameObject[] panels;
    public void Start()
    {
        panels = new GameObject[]
        {
            RoleSettting,
            MainMenu,
            SinglePlayer,
            MultPlayer,
            Setting
        };

    }

    public void ShowRoleSettting()
    {
        ShowPanel(RoleSettting);

    }
    public void ShowMainMenu()
    {
        ShowPanel(MainMenu);

    }
    public void ShowSinglePlayer()
    {
        ShowPanel(SinglePlayer);

    }
    public void ShowMultPlayer()
    {
        ShowPanel(MultPlayer);
    }
    public void ShowSetting()
    {
        ShowPanel(Setting);
    }
    void ShowPanel(GameObject panelToShow)
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(panel == panelToShow);
        }
    }


}
