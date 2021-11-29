using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    //���������ϵ���ʾ ��Ʒ��Ϣ
    
    
    //�������Ϸ���ʾ���ı�����ʾ���������Ϣ
    public string simple;
    
    //��J����ʾ��С�Ի��򣬱�ʾ������ϸ��Ϣ
    [Multiline(5)]
    public string information;


    // ��ʾ����Ƿ������帽��
    private int flag = 0;
    
    private void Update()
    {
        if (flag == 1)
            jud();
    }

    //����������ײ���ⷶΧ�͸���  �������Ϸ���ʾ���ı�����ʾ���������Ϣ  �뿪������ײ���ⷶΧ �������Ϸ���ʾ���ı�����
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


    //��������帽���Ұ���J��PC�ˣ� �� GameManage.flagj����ʾ�ֻ��ϵļ��� ����ʾ С�Ի��� ����С�Ի������ı�����Ϊ  ������ϸ��Ϣ
    //���� Q��pc�ˣ��� GameManage.flagq ����ʾ�ֻ��ϵ��м���Ļ��Χ�� ���˳�С�Ի���
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
