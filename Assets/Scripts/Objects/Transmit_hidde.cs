using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmit_hidde : MonoBehaviour
{
    
    //隐藏传送门　和传送门差不多　只是不需要钥匙
    public GameObject camera1;
    public GameObject camera2;

    public Transform Aim;
    
    public string simple;
    public string info;

    private bool flag = false;
    private bool flag1 = false;
    private void Update()
    {
        if (flag)
            jud();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BagManage.Updataiteminfo(simple);
            flag = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BagManage.Updataiteminfo(simple);
            flag = true;

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BagManage.Updataiteminfo("");
            flag = false;

        }
    }



    void jud()
    {
        if (Input.GetKey(KeyCode.J) || GameManage.flagj)
        {
            UIManage.set_bigtext(info);
            UIManage.transmit();
            flag1 = true;
            GameManage.flagj = false;
        }
        if (flag1)
        {
            if(UIManage.flag == 4)
            {
                camera1.SetActive(false);
                camera2.SetActive(true);
                PlayerManage.transmit(Aim);
                flag1 = false;
            }
            if(UIManage.flag == 3)
            {
                flag1 = false;
            }
        }
    }
}
