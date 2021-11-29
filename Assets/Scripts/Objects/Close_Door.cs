using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Door : MonoBehaviour
{
    //需要钥匙的门
    
    public Bag bag;              // 获取背包
    public string key;           // 钥匙代码
    public GameObject door;     // 一个预制体，表示被打开的门的样子
    private int flag1 = 0;
    private int flag2 = 0;
    private int flag3 = 0;  // 代表人物在门周围

    public string simple;    // 简略信息
    public string big;       // 弹窗 是否打开门
    [Multiline(5)]
    public string information;  // 没钥匙时弹出小对话框
    private void Update()
    {
        //如果人物在门周围
        if(flag3 == 1)
            jud();
    }

    //进入物体碰撞体检测范围就更新  背包栏上方显示的文本，表示物体简略信息  离开物体碰撞体检测范围 背包栏上方显示的文本清零
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            BagManage.Updataiteminfo(simple);
            flag3 = 1;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BagManage.Updataiteminfo(simple);
            flag3 = 1;
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            BagManage.Updataiteminfo("");
            flag3 = 0;
        }
        
    }


    private void jud()
    {
        //循环遍历背包 看背包有没有代码和 此门 需要的钥匙代码一致的 如有flag1 = 1;
        if (flag1 == 0 || flag2 == 0)
        {
            for (int i = 0; i < bag.itemlist.Count; i++)
            {
                if (bag.itemlist[i].itemName == key)
                {
                    flag1 = 1;
                }
            }
            if (Input.GetKey(KeyCode.J) || GameManage.flagj)
            {
                //看玩家是否按了 J 且 如果  没钥匙就弹出小对话框，如果 有 钥匙就弹出是否开门的 弹窗  
                if (flag1 == 0)
                {
                    UIManage.look(information);
                }
                else
                {
                    UIManage.set_bigtext(big);
                    UIManage.open();
                    flag2 = 1;
                }
                //释放J键（手机端）
                GameManage.flagj = false;
            }
        }
        if (flag1 == 1 && flag2 == 1)
        {
            //玩家 按了 J 且 有 钥匙 且 弹窗 上 按的是 确认 就会 UIManage.flag = 2 将关闭的门换成打开的门
            //UIManage.flag = 1 是弹窗 按了 否定 重置 各数据
            if (UIManage.flag == 2)
            {
               
                Instantiate(door, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else if(UIManage.flag == 3)
            {
                flag1 = 0;
                flag2 = 0;
            }
        }
        //关闭 小对话框
        if (Input.GetKey(KeyCode.Q) || GameManage.flagq)
        {
            UIManage.back();
            //释放Q键（中间屏幕范围）（手机端）
            GameManage.flagq = false;
        }
    }
}
