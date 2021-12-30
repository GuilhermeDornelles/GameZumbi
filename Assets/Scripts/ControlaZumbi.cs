using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour
{
    public GameObject jogador;
    public float velocidade = 1f;
    private Movimentacao movimento;
    private Animacao animacaoInimigo;

    void Start()
    {
        jogador = GameObject.FindWithTag("Player");        
        animacaoInimigo = GetComponent<Animacao>();
        movimento = GetComponent<Movimentacao>();
        aleatorizarZumbi();
    }

    private void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);

        Vector3 direcao = jogador.transform.position - transform.position;

        movimento.rotacionar(direcao);

        if (distancia > 2.5)
        {
            movimento.movimentar(direcao, velocidade);
            animacaoInimigo.atacar(false);
        } 
        else
        {
            animacaoInimigo.atacar(true);
        }
    }

    void AtacaJogador()
    {
        int dano = Random.Range(20, 31);
        jogador.GetComponent<ControlaJogador>().tomarDano(dano);
        
    }

    void aleatorizarZumbi()
    {
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }
}
