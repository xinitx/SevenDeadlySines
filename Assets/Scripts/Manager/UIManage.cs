using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManage : MonoBehaviour
{
    public static UIManage instance;
    //�գɹ���

    public float player_health;    ������//���������
    public Slider bosshealth;������������//�������������
    public Slider playerhealth;����������//����ҡ�������

    public Canvas sign;������������������//���������գ�
    public Canvas bag;������������������//���������գ�

    public GameObject talk_info;��������//��С�Ի���

    public Text small_text;����������//��С�Ի����ı�
    public Text big_text;������������//�������ı�


    
    public static  int flag = 0;
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;

        
    }

    //�����š�������ͣ
    public static void open()
    {
        flag = 0;
        instance.sign.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    //�����͡�������ͣ
    public static void transmit()
    {
        flag = 1;
        instance.sign.gameObject.SetActive(true);
        Time.timeScale = 0;
        
    }

    //���µ����ı�
    public static void set_bigtext(string message)
    {
        instance.big_text.text = message;
    }
    //ȷ��������ǡ����š�����2���Ǵ��ͷ��ء�4
    public void   comfirm()
    {
        Time.timeScale = 1;
        sign.gameObject.SetActive(false);
        if (flag == 1)
            flag = 4;
        else
            flag = 2;
        
    }
    //ȡ�������ء�3
    public void  cancel()
    {
        Time.timeScale = 1;
        sign.gameObject.SetActive(false);
        flag = 3;
    }



    //��С�Ի���
    public static void look(string info)
    {
        //���ر���
        instance.bag.gameObject.SetActive(false);
        //�����ı�
        instance.talk_info.SetActive(true);
        instance.small_text.text = info;
        Time.timeScale = 0;
    }
    //����С�Ի���
    public static void back()
    {
        instance.bag.gameObject.SetActive(true);
        instance.talk_info.SetActive(false);
        instance.small_text.text = "";
    }
    //�����£��������ֵ
    public void updataBossHealth(int health)
    {
        bosshealth.value += health;
    }
    //�������������ֵ
    public void updataPlayerHealth(float health)
    {
        player_health += health;
        playerhealth.value = player_health;
    }
}
