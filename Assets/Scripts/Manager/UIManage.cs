using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManage : MonoBehaviour
{
    public static UIManage instance;
    //ＵＩ管理

    public float player_health;    　　　//　玩家生命
    public Slider bosshealth;　　　　　　//　ｂｏｓｓ生命条
    public Slider playerhealth;　　　　　//　玩家　生命条

    public Canvas sign;　　　　　　　　　//　弹窗　ＵＩ
    public Canvas bag;　　　　　　　　　//　背包　ＵＩ

    public GameObject talk_info;　　　　//　小对话框

    public Text small_text;　　　　　//　小对话框文本
    public Text big_text;　　　　　　//　弹窗文本


    
    public static  int flag = 0;
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;

        
    }

    //　开门　弹窗暂停
    public static void open()
    {
        flag = 0;
        instance.sign.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    //　传送　弹窗暂停
    public static void transmit()
    {
        flag = 1;
        instance.sign.gameObject.SetActive(true);
        Time.timeScale = 0;
        
    }

    //更新弹窗文本
    public static void set_bigtext(string message)
    {
        instance.big_text.text = message;
    }
    //确定　如果是　开门　返回2　是传送返回　4
    public void   comfirm()
    {
        Time.timeScale = 1;
        sign.gameObject.SetActive(false);
        if (flag == 1)
            flag = 4;
        else
            flag = 2;
        
    }
    //取消　返回　3
    public void  cancel()
    {
        Time.timeScale = 1;
        sign.gameObject.SetActive(false);
        flag = 3;
    }



    //　小对话框
    public static void look(string info)
    {
        //　关背包
        instance.bag.gameObject.SetActive(false);
        //　改文本
        instance.talk_info.SetActive(true);
        instance.small_text.text = info;
        Time.timeScale = 0;
    }
    //　关小对话框
    public static void back()
    {
        instance.bag.gameObject.SetActive(true);
        instance.talk_info.SetActive(false);
        instance.small_text.text = "";
    }
    //　更新ｂｏｓｓ生命值
    public void updataBossHealth(int health)
    {
        bosshealth.value += health;
    }
    //　更新玩家生命值
    public void updataPlayerHealth(float health)
    {
        player_health += health;
        playerhealth.value = player_health;
    }
}
