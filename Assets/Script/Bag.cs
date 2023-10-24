using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bag", menuName = "Bag")]
public class Bag : ScriptableObject
{
    public List<BagSlot> bag = new List<BagSlot>();

    public void AddItem(Item _item, int _amount)
    {
        //Verificando se existe cópia do item
        bool hasItem = false;

        for (int i=0; i< bag.Count; i++)
        {
            if (bag[i].item == _item)
            {
                bag[i].AddAmount(_amount);
                hasItem = true;
                break;
            }

        }
        if (!hasItem)
        {
            bag.Add(new BagSlot(_item, _amount));
        }
    }

}

[System.Serializable]
public class BagSlot
{
    public Item item;
    public int amount;

    //Constructor
    public BagSlot(Item _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
