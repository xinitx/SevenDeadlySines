using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    //挂在物体上的显示 物品信息
    
    
    //背包栏上方显示的文本，表示物体简略信息
    public string simple;
    
    //按J后显示的小对话框，表示物体详细信息
    [Multiline(5)]
    public string information;


    // 表示玩家是否在物体附近
    private int flag = 0;
    
    private void Update()
    {
        if (flag == 1)
            jud();
    }

    //进入物体碰撞体检测范围就更新  背包栏上方显示的文本，表示物体简略信息  离开物体碰撞体检测范围 背包栏上方显示的文本清零
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BagManage.Updataiteminfo(simple);
            flag = 1;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            BagManage.Updataiteminfo(simple);
            flag = 1;
            
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BagManage.Updataiteminfo("");
            flag = 0;
        }
    }


    //玩家在物体附近且按了J（PC端） 或 GameManage.flagj（表示手机上的键） 就显示 小对话框 并将小对话框中文本更新为  物体详细信息
    //按了 Q（pc端）或 GameManage.flagq （表示手机上的中间屏幕范围） 就退出小对话框
    private void jud()
    {
        if (Input.GetKey(KeyCode.J) || GameManage.flagj)
        {
            UIManage.look(information);
            GameManage.flagj = false;
        }
        if (Input.GetKey(KeyCode.Q) || GameManage.flagq)
        {
            UIManage.back();
            GameManage.flagq = false;
        }
    }
}
