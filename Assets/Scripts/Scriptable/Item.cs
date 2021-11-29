using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "Bag/new item")]
public class Item : ScriptableObject
{
    //�ɼ�ʰ��Ʒ
    public string itemName;
    public Sprite itemImage;
    public string iteminfo;
}
