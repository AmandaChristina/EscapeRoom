using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Equipment Item")]

public class Equipment : Item
{
    public void Awake()
    {
        type = ItemType.Equipment;
    }

}
