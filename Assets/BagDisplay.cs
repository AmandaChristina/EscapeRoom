using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class BagDisplay : MonoBehaviour
{
    public List<Image> slots = new List<Image>();
    public Bag bag;

    private void Awake()
    {
        foreach (Transform slot in gameObject.transform)
        {
            slots.Add(slot.gameObject.GetComponent<Image>());
        }
    }
    private void Update()
    {
        
        for (int i=0; i < slots.Count; i++)
        {
            if (bag.bag[i] != null) slots[i].sprite = bag.bag[i].item.sprite;
        }
    }
    
}
