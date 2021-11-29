using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagGrid : MonoBehaviour
{
    //单元格
    //背包ＵＩ
    public Bag inventory;
    //单元格代表的物体
    public Item thisitem;
    //单元格图片
    public Image thisimage;
    //单元格序号
    private int order;

    
    public bool click = false;
    public void itemclick()
    {
        //点击一次单元格，更新BagManage内的单元格序号，更新背包栏简略介绍
        if (!click)
        {
            BagManage.Updataiteminfo(thisitem.iteminfo);
            BagManage.updataorder(order);
        }
        //再点击一次，重置背包栏简略介绍，BagManage内的单元格序号设为ＮＵｌｌ，取消选择的意思
        if (click)
        {
            BagManage.Updataiteminfo("");
            BagManage.updataorder(5);
        }
        click = BagManage.jud[order];


    }
    //丢弃物品
    public void dropitem()
    {
        //背包中删除
        inventory.itemlist.RemoveAt(order);
        //重新启用物体，并改坐标为人物旁边
        inventory.objectlist[order].SetActive(true);
        inventory.objectlist[order].transform.position = FindObjectOfType<PlayerManage>().transform.position + new Vector3(0, 2, 0);
        inventory.objectlist.RemoveAt(order);
        //更新背包ＵＩ
        BagManage.UpdataItem();

    }
    //更改单元格序号，更新背包ＵＩ时调用
    public void getorder(int midorder)
    {
        order = midorder;
    }
}
