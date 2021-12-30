using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    public float velocidade = 1f;
    Vector3 direcao;
    public LayerMask mascaraDoChao;
    public GameObject textoGameOver;    
    public int vida=100;
    public ControlaInterface scriptControlaInteface;
    public AudioClip somDano;
    private MovimentoJogador movimentoJogador;
    private Animacao animacaoJogador;

    public void Start()
    {
        Time.timeScale = 1;
        //Deixar o código mais otimizado
        movimentoJogador = GetComponent<MovimentoJogador>();
        animacaoJogador = GetComponent<Animacao>();
    }

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal"); //Pega o eixo
        float eixoZ = Input.GetAxis("Vertical");
        direcao = new Vector3(eixoX, 0, eixoZ);

        animacaoJogador.movimentar(direcao.magnitude); //magnitude = tamanho do vector3


        if(vida<=0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("game");
            }
        }
    }

    private void FixedUpdate()
    {
        movimentoJogador.movimentar(direcao, velocidade);
        movimentoJogador.rotacaoJogador(mascaraDoChao);
    }   
    public void tomarDano(int dano)
    {
        vida -= dano;
        scriptControlaInteface.atualizarSliderVidaJogador();
        ControlaAudio.instance.PlayOneShot(somDano);
        if(vida <= 0)
        {
            Time.timeScale = 0;
            textoGameOver.SetActive(true);           
        }
    }
}
