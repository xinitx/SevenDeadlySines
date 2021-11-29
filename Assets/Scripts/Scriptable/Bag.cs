using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bag", menuName = "Bag/new Bag")]
public class Bag : ScriptableObject
{
    //±³°ü
    public List<Item> itemlist = new List<Item>();
    
    public List<GameObject> objectlist = new List<GameObject>();
}
