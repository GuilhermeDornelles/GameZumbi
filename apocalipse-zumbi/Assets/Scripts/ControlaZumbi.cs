using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour
{
    public GameObject jogador;
    public float velocidade=1f;
    private Rigidbody rigidbodyZumbi;
    private Animator animatorZumbi;    

    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        int geraTipoZumbi = Random.RandomRange(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
        rigidbodyZumbi = GetComponent<Rigidbody>();
        animatorZumbi = GetComponent<Animator>();        
    }

    private void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);

        Vector3 direcao = jogador.transform.position - transform.position;

        Quaternion novaRotacao = Quaternion.LookRotation(direcao);  //Calcula a rotacao baseada em uma posição
        rigidbodyZumbi.MoveRotation(novaRotacao);
        if (distancia > 2.5)
        {         
            rigidbodyZumbi.MovePosition(rigidbodyZumbi.position + direcao.normalized * velocidade * Time.deltaTime);
            animatorZumbi.SetBool("Atacando", false);
        } 
        else
        {
            animatorZumbi.SetBool("Atacando", true);
        }
    }

    void AtacaJogador()
    {
        int dano = Random.Range(20, 31);
        jogador.GetComponent<ControlaJogador>().tomarDano(dano);
        
    }
}
