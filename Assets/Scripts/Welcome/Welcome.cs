using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    //开场动画　用　加载游戏场景
    private void finish()
    {
        SceneManager.LoadScene(1);
        
    }

}
