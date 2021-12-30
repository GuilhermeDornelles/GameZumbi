using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour
{
    public GameObject jogador;
    public float velocidade=1f;
    private Animator animatorZumbi;
    private Movimentacao movimento;

    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);        
        animatorZumbi = GetComponent<Animator>();
        movimento = GetComponent<Movimentacao>();
    }

    private void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);

        Vector3 direcao = jogador.transform.position - transform.position;

        movimento.rotacionar(direcao);

        if (distancia > 2.5)
        {
            movimento.movimentar(direcao, velocidade);
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
