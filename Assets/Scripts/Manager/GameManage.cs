using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManage : MonoBehaviour
{
    //��Ϸ����
    
    static public GameManage instance;
    //����
    public Bag bag;
    //�ֻ��˵����Ҽ� ����Уõġ��ʺ͡����
    public static bool flagj = false;
    public static bool flagq = false;
    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        
    }

    //���ˡ��ֻ��˵ġ����
    public void continuekey()
    {
        Time.timeScale = 1;
        flagq = true;
    }
    //���ˡ��ֻ��˵ġ����
    public void jdown()
    {
        flagj = true;
    }
    //��ʼ��Ϸ
    public void StartGame()
    {
        bag.itemlist.Clear();
        bag.objectlist.Clear();
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    } 
    //�˳���Ϸ
    public void ExitGame()
    {
        Application.Quit();
    }

}
