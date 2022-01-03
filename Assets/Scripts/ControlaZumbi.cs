using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour, IMatavel
{
    public GameObject jogador;    
    private Movimentacao movimento;
    private Animacao animacaoInimigo;
    private Status statusZumbi;
    public AudioClip somMorte;
    private Vector3 posicaoAleatoria;
    private Vector3 direcao;
    private float contadorVagar;
    private float tempoPosicoesAleatorias = 4f;

    void Start()
    {
        jogador = GameObject.FindWithTag(Tags.jogador);        
        animacaoInimigo = GetComponent<Animacao>();
        movimento = GetComponent<Movimentacao>();
        statusZumbi = GetComponent<Status>();
        aleatorizarZumbi();
    }

    private void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);
        movimento.rotacionar(direcao);
        animacaoInimigo.movimentar(direcao.magnitude);

        if(distancia > 15)
        {
            vagar();
        }
        else if (distancia > 2.5)
        {
            direcao = jogador.transform.position - transform.position;
            movimento.movimentar(direcao, statusZumbi.velocidade);
            animacaoInimigo.atacar(false);
        } 
        else
        {
            direcao = jogador.transform.position - transform.position;
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

    public void tomarDano(int dano)
    {
        statusZumbi.vida -= dano;
        if (statusZumbi.vida <= 0){
            morrer();
        }
    }

    public void morrer()
    {
        Destroy(gameObject);
        ControlaAudio.instance.PlayOneShot(somMorte);
    }

    void vagar()
    {
        contadorVagar -= Time.deltaTime;
        if(contadorVagar <= 0)
        {
            posicaoAleatoria = aleatorizarPosicao();
            contadorVagar += tempoPosicoesAleatorias;
        }
        bool pertoSuficiente = Vector3.Distance(transform.position, posicaoAleatoria) <= 0.05;
        if (!pertoSuficiente)
        {
            direcao = posicaoAleatoria - transform.position;
            movimento.movimentar(direcao, statusZumbi.velocidade);
        }        
    }

    Vector3 aleatorizarPosicao()
    {
        Vector3 posicao = Random.insideUnitSphere * 10;//gera uma posicao dentro de uma esfera de raio 1
        posicao += transform.position;
        posicao.y = transform.position.y;
        return posicao;
    }
}
