using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iteminworld : MonoBehaviour
{
    public Item item;
    public Bag inventory;

    //�ɼ�ʰ������

    //�����������
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
        }
        
    }
    //���뱳���б����±����գɡ�����������
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
