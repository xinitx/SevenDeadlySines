using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BagManage : MonoBehaviour
{
    static BagManage instance;

    //�������գɹ���
    //����
    public Bag bag;
    //������
    public GameObject inventory;
    //��Ԫ��
    public BagGrid grid;
    //�����Ԫ��������
    public Text Describe;

    //��Ԫ������Ʒ��ű��������һ�̵���ĵ�Ԫ����š��ĸ�Ϊ��������˵���ĸ�Ϊ���һ�̵���ĵ�Ԫ�����
    public static List<bool> jud = new List<bool>();

    //��ǰ���һ�̵���ĵ�Ԫ����š���ʼΪ5����Σգ̣�
    public static int order = 5;
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
        
        //���õ�Ԫ����Ʒ����
        UpdataItem();
        instance.Describe.text = "";

        //��ʼ����
        for(int i = 0; i < 6; i ++ )
        {
            jud.Add(false);
        }
    }
    //���µ�Ԫ����Ʒ����
    public static void Updataiteminfo(string mytext)
    {
        instance.Describe.text = mytext;
    }
    //���������µ�Ԫ��
    public static void UpdataItem()
    {
        //�Ȱѵ�Ԫ��ȫɾ��
        for(int i = 0; i < instance.transform.childCount; i++)
        {
            Destroy(instance.transform.GetChild(i).gameObject);
        }
        //������������Ԫ��
        for (int i = 0; i < instance.bag.itemlist.Count; i ++ )
        {
            //����Ԥ����
            BagGrid mid = Instantiate(instance.grid, instance.inventory.transform.position, Quaternion.identity);
            //���ø�����Ϊ�����գ�
            mid.gameObject.transform.SetParent(instance.inventory.transform);
            //���µ�Ԫ����Ϣ
            mid.thisitem = instance.bag.itemlist[i];
            mid.thisimage.sprite = instance.bag.itemlist[i].itemImage;
            mid.getorder(i);
        }
        
    }
    //�������һ�̵���ĵ�Ԫ�����
    public static void updataorder(int theorder)
    {
        //���һ�̵���ĵ�Ԫ�������Ϊ�����������Ϊ������
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
