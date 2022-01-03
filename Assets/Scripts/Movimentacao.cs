using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    private Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void movimentar(Vector3 direcao, float velocidade)
    {
        rigidBody.MovePosition(rigidBody.position + direcao.normalized * velocidade * Time.deltaTime);
        
    }

    public void rotacionar(Vector3 direcao){
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);  //Calcula a rotacao baseada em uma posição
        rigidBody.MoveRotation(novaRotacao);
    }
}
