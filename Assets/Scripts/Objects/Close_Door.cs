using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Door : MonoBehaviour
{
    //��ҪԿ�׵���
    
    public Bag bag;              // ��ȡ����
    public string key;           // Կ�״���
    public GameObject door;     // һ��Ԥ���壬��ʾ���򿪵��ŵ�����
    private int flag1 = 0;
    private int flag2 = 0;
    private int flag3 = 0;  // ��������������Χ

    public string simple;    // ������Ϣ
    public string big;       // ���� �Ƿ����
    [Multiline(5)]
    public string information;  // ûԿ��ʱ����С�Ի���
    private void Update()
    {
        //�������������Χ
        if(flag3 == 1)
            jud();
    }

    //����������ײ���ⷶΧ�͸���  �������Ϸ���ʾ���ı�����ʾ���������Ϣ  �뿪������ײ���ⷶΧ �������Ϸ���ʾ���ı�����
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
        //ѭ���������� ��������û�д���� ���� ��Ҫ��Կ�״���һ�µ� ����flag1 = 1;
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
                //������Ƿ��� J �� ���  ûԿ�׾͵���С�Ի������ �� Կ�׾͵����Ƿ��ŵ� ����  
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
                //�ͷ�J�����ֻ��ˣ�
                GameManage.flagj = false;
            }
        }
        if (flag1 == 1 && flag2 == 1)
        {
            //��� ���� J �� �� Կ�� �� ���� �� ������ ȷ�� �ͻ� UIManage.flag = 2 ���رյ��Ż��ɴ򿪵���
            //UIManage.flag = 1 �ǵ��� ���� �� ���� ������
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
        //�ر� С�Ի���
        if (Input.GetKey(KeyCode.Q) || GameManage.flagq)
        {
            UIManage.back();
            //�ͷ�Q�����м���Ļ��Χ�����ֻ��ˣ�
            GameManage.flagq = false;
        }
    }
}
