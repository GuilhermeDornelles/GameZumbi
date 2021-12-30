using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : Movimentacao
{
    public void rotacaoJogador(LayerMask mascaraDoChao)
    {
        //Para mirar
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto; //Guarda a posição que o raio toca o chão

        if (Physics.Raycast(raio, out impacto, 100, mascaraDoChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position; //baseado na posição do jogador
            posicaoMiraJogador.y = transform.position.y;

            rotacionar(posicaoMiraJogador);      
        }
    }
}
