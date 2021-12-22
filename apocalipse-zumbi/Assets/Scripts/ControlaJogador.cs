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
    private Rigidbody rigidbodyJogador;
    private Animator animatorJogador;
    public int vida=100;
    public ControlaInterface scriptControlaInteface;
    public AudioClip somDano;

    public void Start()
    {
        Time.timeScale = 1;
        //Deixar o código mais otimizado
        rigidbodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
    }

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal"); //Pega o eixo
        float eixoZ = Input.GetAxis("Vertical");
        direcao = new Vector3(eixoX, 0, eixoZ);

        if (direcao != Vector3.zero)
        {
            animatorJogador.SetBool("Movendo", true);
        } else
        {
            animatorJogador.SetBool("Movendo", false);
        }

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
        rigidbodyJogador.MovePosition(rigidbodyJogador.position + (direcao * Time.deltaTime * velocidade));//Por segundo

        //Para mirar
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto; //Guarda a posição que o raio toca o chão

        if(Physics.Raycast(raio, out impacto, 100, mascaraDoChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position; //baseado na posição do jogador
            posicaoMiraJogador.y = transform.position.y;
            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            rigidbodyJogador.MoveRotation(novaRotacao);
        }
        
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
