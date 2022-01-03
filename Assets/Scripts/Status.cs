using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int vidaInicial = 100;
    [HideInInspector] //Não aparece na Unity
    public int vida;
    public float velocidade = 5;

    void Awake()
    {
        vida = vidaInicial;
    }
}
