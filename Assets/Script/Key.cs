using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    //Função Empacotada
    public void TheyKey()
    {
        print("Eu sou uma chave");
    }

    //Função empacotada
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
