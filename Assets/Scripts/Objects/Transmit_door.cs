using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmit_door : MonoBehaviour
{
    //传送门
    
    //改变相机
    public GameObject camera1;
    public GameObject camera2;
    //目标点
    public Transform Aim;
    //背包
    public Bag bag;
    //需要的钥匙
    public string key;
    //简略信息
    public string simple;
    //开门时弹窗文本
    public string info;
    //和　需要钥匙的门　差不多
    private bool flag1 = false;
    private bool flag2 = false;
    private bool flag3 = false;

    private void Update()
    {
        if(flag3)
        {
            jud();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BagManage.Updataiteminfo(simple);
            flag3 = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            BagManage.Updataiteminfo(simple);
            flag3 = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BagManage.Updataiteminfo("");
            flag3 = false;
        }
    }
    void jud()
    {
        if (!flag1)
        {
            for (int i = 0; i < bag.itemlist.Count; i++)
            {
                if (bag.itemlist[i].itemName == key)
                {
                    flag1 = true;
                    break;
                }
                flag1 = false;
            }
        }
        if (Input.GetKey(KeyCode.J) || GameManage.flagj)
        {
            flag2 = true;
            GameManage.flagj = false;
            if(flag1)
            {
                UIManage.set_bigtext(info);
                UIManage.transmit();
            }
        }
        if (flag1 && flag2)
        {
            
            if (UIManage.flag == 4)
            {
                camera1.SetActive(false);
                camera2.SetActive(true);
                PlayerManage.transmit(Aim);
                flag1 = false;
                flag2 = false;
            }
            if (UIManage.flag == 3)
            {
                flag1 = false;
                flag2 = false;
            }
        }
    }
}
