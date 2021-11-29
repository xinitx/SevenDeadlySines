using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagGrid : MonoBehaviour
{
    //��Ԫ��
    //�����գ�
    public Bag inventory;
    //��Ԫ����������
    public Item thisitem;
    //��Ԫ��ͼƬ
    public Image thisimage;
    //��Ԫ�����
    private int order;

    
    public bool click = false;
    public void itemclick()
    {
        //���һ�ε�Ԫ�񣬸���BagManage�ڵĵ�Ԫ����ţ����±��������Խ���
        if (!click)
        {
            BagManage.Updataiteminfo(thisitem.iteminfo);
            BagManage.updataorder(order);
        }
        //�ٵ��һ�Σ����ñ��������Խ��ܣ�BagManage�ڵĵ�Ԫ�������Ϊ�Σգ�죬ȡ��ѡ�����˼
        if (click)
        {
            BagManage.Updataiteminfo("");
            BagManage.updataorder(5);
        }
        click = BagManage.jud[order];


    }
    //������Ʒ
    public void dropitem()
    {
        //������ɾ��
        inventory.itemlist.RemoveAt(order);
        //�����������壬��������Ϊ�����Ա�
        inventory.objectlist[order].SetActive(true);
        inventory.objectlist[order].transform.position = FindObjectOfType<PlayerManage>().transform.position + new Vector3(0, 2, 0);
        inventory.objectlist.RemoveAt(order);
        //���±����գ�
        BagManage.UpdataItem();

    }
    //���ĵ�Ԫ����ţ����±����գ�ʱ����
    public void getorder(int midorder)
    {
        order = midorder;
    }
}
