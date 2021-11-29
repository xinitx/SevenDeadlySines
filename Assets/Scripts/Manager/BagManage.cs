using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BagManage : MonoBehaviour
{
    static BagManage instance;

    //　背包ＵＩ管理
    //背包
    public Bag bag;
    //背包栏
    public GameObject inventory;
    //单元格
    public BagGrid grid;
    //点击单元格后的描述
    public Text Describe;

    //单元格内物品序号表，设置最近一刻点击的单元格序号　哪个为ｔｒｕｅ就说明哪个为最近一刻点击的单元格序号
    public static List<bool> jud = new List<bool>();

    //当前最近一刻点击的单元格序号　初始为5代表ＮＵＬＬ
    public static int order = 5;
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
        
        //重置单元格物品描述
        UpdataItem();
        instance.Describe.text = "";

        //初始化表
        for(int i = 0; i < 6; i ++ )
        {
            jud.Add(false);
        }
    }
    //更新单元格物品描述
    public static void Updataiteminfo(string mytext)
    {
        instance.Describe.text = mytext;
    }
    //按背包更新单元格
    public static void UpdataItem()
    {
        //先把单元格全删除
        for(int i = 0; i < instance.transform.childCount; i++)
        {
            Destroy(instance.transform.GetChild(i).gameObject);
        }
        //按背包创建单元格
        for (int i = 0; i < instance.bag.itemlist.Count; i ++ )
        {
            //创建预制体
            BagGrid mid = Instantiate(instance.grid, instance.inventory.transform.position, Quaternion.identity);
            //设置父物体为背包ＵＩ
            mid.gameObject.transform.SetParent(instance.inventory.transform);
            //更新单元格信息
            mid.thisitem = instance.bag.itemlist[i];
            mid.thisimage.sprite = instance.bag.itemlist[i].itemImage;
            mid.getorder(i);
        }
        
    }
    //更新最近一刻点击的单元格序号
    public static void updataorder(int theorder)
    {
        //最近一刻点击的单元格序号设为ｔｒｕｅ其他为ｆａｌｓｅ
        order = theorder;
        for (int i = 0; i < 6; i++)
        {
            if (i != order)
                jud[i] = false;
            else
                jud[i] = true;
        }
    }
}
