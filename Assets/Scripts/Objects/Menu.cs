using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //�˵�����
    
    public GameObject penal;//�˵��գ�
    public GameObject UI;��//�������գ�
    public GameObject menu;��//�˵�����


    //�򿪲˵���ͬʱ�رղ˵��������������Уգ�
    public void openmenu()
    {
        UI.SetActive(false);
        penal.SetActive(true);
        menu.SetActive(false);
        Time.timeScale = 0;
    }

    //������Ϸ��ͬʱ�򿪲˵��������������Уգ�
    public void continuegame()
    {
        UI.SetActive(true);
        penal.SetActive(false);
        menu.SetActive(true);
        Time.timeScale = 1;
    }
}
