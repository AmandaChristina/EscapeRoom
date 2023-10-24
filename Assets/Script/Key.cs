using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Key Item")]
public class Key : Item
{
    public int id;
    

    public void Awake()
    {
        type = ItemType.Keys;
    }

}
