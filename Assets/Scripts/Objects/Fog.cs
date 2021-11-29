using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    //迷雾效果
    //获得图像组件
    new private Renderer renderer;
    private int i = 255;
    private float second = 0.005f;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine("wait_reappear");
            StartCoroutine("wait_decay");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine("wait_decay");
            StartCoroutine("wait_reappear");
        }
    }
    //人物进入时透明度值降低
    IEnumerator wait_decay()
    {
        for (; i > 0; i--)
        {
            
            yield return new WaitForSeconds(second);
            renderer.material.color = new Color32(0, 0, 0, (byte)i);
        }
    }
    //人物离开时透明度值增高
    IEnumerator wait_reappear()
    {
        for (; i < 255; i++)
        {
            
            yield return new WaitForSeconds(second);
            renderer.material.color = new Color32(0, 0, 0, (byte)i);
        }
    }
}
