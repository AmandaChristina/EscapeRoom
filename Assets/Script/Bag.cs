using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public List<GameObject> bag = new List<GameObject>();

    public void InsertBag(GameObject item)
    {
        bag.Add(item);
    }


}
