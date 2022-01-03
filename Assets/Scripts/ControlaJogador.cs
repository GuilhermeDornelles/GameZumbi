using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour, IMatavel
{    
    Vector3 direcao;
    public LayerMask mascaraDoChao;
    public GameObject textoGameOver;    
    public ControlaInterface scriptControlaInteface;
    public AudioClip somDano;
    private MovimentoJogador movimentoJogador;
    private Animacao animacaoJogador;
    public Status statusJogador;

    public void Start()
    {
        //Deixar o código mais otimizado
        movimentoJogador = GetComponent<MovimentoJogador>();
        animacaoJogador = GetComponent<Animacao>();
        statusJogador = GetComponent<Status>();
    }

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal"); //Pega o eixo
        float eixoZ = Input.GetAxis("Vertical");
        direcao = new Vector3(eixoX, 0, eixoZ);

        animacaoJogador.movimentar(direcao.magnitude); //magnitude = tamanho do vector3
    }

    private void FixedUpdate()
    {
        movimentoJogador.movimentar(direcao, statusJogador.velocidade);
        movimentoJogador.rotacaoJogador(mascaraDoChao);
    }   
    public void tomarDano(int dano)
    {
        statusJogador.vida -= dano;
        scriptControlaInteface.atualizarSliderVidaJogador();
        ControlaAudio.instance.PlayOneShot(somDano);
        if(statusJogador.vida <= 0)
        {
            morrer();
        }
    }

    public void morrer() {  
        scriptControlaInteface.GameOver();
    }
}
