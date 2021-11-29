using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�����ӵ��ϵĿ���

    //�ӵ�Ŀ������
    private Transform target;
    
    //�ӵ����������ά��������startʱ�����
    Vector3 position;
    private void Start()
    {
        position = PlayerManage.instance.transform.position - transform.position;
    }
    //�ӵ����ƶ�
    private void Update()
    {
        MovetoTarget();
    }

    //�ӵ�����ʱ������Ѫ�� �����ӵ�
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
    

    //�ӵ����ƶ� ��ǰ����ӷ�������
    private void MovetoTarget()
    {
        
        transform.position += position * Time.deltaTime;
    }
}
