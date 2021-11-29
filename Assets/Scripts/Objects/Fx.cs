using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fx : MonoBehaviour
{
    // Start is called before the first frame update
    //攻击　若碰到ｂｏｓｓ减其生命值
    public void finish()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            UIManage.instance.updataBossHealth(-1);
        }
    }

}
