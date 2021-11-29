using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //敌人控制
    

    //巡逻点的表
    public List<Transform> target = new List<Transform>();
    //当前目标点
    public Transform targetPoint;
    //子弹预制体
    public Bullet bullet;

    //巡逻点坐标表的下标
    private int init = 0;

    private float speed = 2f;
    
    void Start()
    {
        //初始化目标点
        targetPoint = target[init];
    }

   //到达当前目标点换到下个目标点
    void Update()
    {
        if(transform.position == targetPoint.position)
        {
            if (init != target.Count - 1)
                init += 1;
            else
                init = 0;
            targetPoint = target[init];
        }
        
        MovetoTarget();

    }

    //敌人的翻转和移动，左右移动方向变化时翻转
    private void MovetoTarget()
    {
        if(targetPoint.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
            transform.localScale = new Vector3(1, 1, 1);
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        
    }

    //如果发现玩家 目标点换成玩家，玩家离开 目标点重置
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            targetPoint = collision.transform;
            Attack();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetPoint = target[init];
        }
    }

    //攻击 创建子弹
    private void Attack()
    {
        Instantiate(bullet, transform.position + new Vector3(transform.localScale.x,0,0), Quaternion.identity);
    }
}
