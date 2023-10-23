using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //Adicionar biblioteca de eventos

public class Item : MonoBehaviour
{
    //Criar uma variável tipo evento
    public UnityEvent _itemEvent;
    public string _name, _description, _textItem;
    Bag bagScript;

    private void Start()
    {
        bagScript = GameObject.Find("Player").GetComponent<Bag>();
    }

    public string OnFocus()
    {
        return _textItem = _name + "\n \n" + _description;

    }

    public void CollectMe(GameObject item)
    {
        bagScript.InsertBag(item);
    }


}
