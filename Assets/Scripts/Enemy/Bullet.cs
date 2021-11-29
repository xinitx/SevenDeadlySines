using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //挂在子弹上的控制

    //子弹目标坐标
    private Transform target;
    
    //子弹到人物的三维向量并在start时算出来
    Vector3 position;
    private void Start()
    {
        position = PlayerManage.instance.transform.position - transform.position;
    }
    //子弹的移动
    private void Update()
    {
        MovetoTarget();
    }

    //子弹命中时减人物血量 销毁子弹
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            UIManage.instance.updataPlayerHealth(-1);
        }
    
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            UIManage.instance.updataPlayerHealth(-1);
        }
        Destroy(gameObject);
    }
    

    //子弹的移动 当前坐标加方向向量
    private void MovetoTarget()
    {
        
        transform.position += position * Time.deltaTime;
    }
}
