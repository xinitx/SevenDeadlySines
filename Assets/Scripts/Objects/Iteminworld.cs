using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iteminworld : MonoBehaviour
{
    public Item item;
    public Bag inventory;

    //可捡拾的物体

    //玩家碰到物体
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
        }
        
    }
    //加入背包列表　更新背包ＵＩ　将物体销毁
    public void AddNewItem()
    {
        if (inventory.itemlist.Count < 5)
        {
            inventory.itemlist.Add(item);
            inventory.objectlist.Add(gameObject);
            BagManage.UpdataItem();
            gameObject.SetActive(false);
        }
    }
   
}
