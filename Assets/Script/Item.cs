using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //Adicionar biblioteca de eventos



public enum ItemType
{
    Keys,
    Default,
    Consumables,
    Equipment
}



public class Item : ScriptableObject
{

    public new string name;
    [TextArea(5,20)]
    public string description;
    public ItemType type;
    public GameObject prefab;
    public Sprite sprite;
  

}
