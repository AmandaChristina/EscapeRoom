using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    //Fun��o Empacotada
    public void TheyKey()
    {
        print("Eu sou uma chave");
    }

    //Fun��o empacotada
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
