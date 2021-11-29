using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //���˿���
    

    //Ѳ�ߵ�ı�
    public List<Transform> target = new List<Transform>();
    //��ǰĿ���
    public Transform targetPoint;
    //�ӵ�Ԥ����
    public Bullet bullet;

    //Ѳ�ߵ��������±�
    private int init = 0;

    private float speed = 2f;
    
    void Start()
    {
        //��ʼ��Ŀ���
        targetPoint = target[init];
    }

   //���ﵱǰĿ��㻻���¸�Ŀ���
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

    //���˵ķ�ת���ƶ��������ƶ�����仯ʱ��ת
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

    //���������� Ŀ��㻻����ң�����뿪 Ŀ�������
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

    //���� �����ӵ�
    private void Attack()
    {
        Instantiate(bullet, transform.position + new Vector3(transform.localScale.x,0,0), Quaternion.identity);
    }
}
