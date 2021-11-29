using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManage : MonoBehaviour
{
    //游戏控制
    
    static public GameManage instance;
    //背包
    public Bag bag;
    //手机端的左右键 代表ＰＣ的　Ｊ和　ｑ键
    public static bool flagj = false;
    public static bool flagq = false;
    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        
    }

    //按了　手机端的　ｑ键
    public void continuekey()
    {
        Time.timeScale = 1;
        flagq = true;
    }
    //按了　手机端的　ｊ键
    public void jdown()
    {
        flagj = true;
    }
    //开始游戏
    public void StartGame()
    {
        bag.itemlist.Clear();
        bag.objectlist.Clear();
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    } 
    //退出游戏
    public void ExitGame()
    {
        Application.Quit();
    }

}
