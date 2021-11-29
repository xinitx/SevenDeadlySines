using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //菜单按键
    
    public GameObject penal;//菜单ＵＩ
    public GameObject UI;　//　其他ＵＩ
    public GameObject menu;　//菜单按键


    //打开菜单，同时关闭菜单按键和其他所有ＵＩ
    public void openmenu()
    {
        UI.SetActive(false);
        penal.SetActive(true);
        menu.SetActive(false);
        Time.timeScale = 0;
    }

    //继续游戏，同时打开菜单按键和其他所有ＵＩ
    public void continuegame()
    {
        UI.SetActive(true);
        penal.SetActive(false);
        menu.SetActive(true);
        Time.timeScale = 1;
    }
}
