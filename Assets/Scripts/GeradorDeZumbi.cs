using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeZumbi : MonoBehaviour
{
    public GameObject zumbi;
    float contadorTempo = 0;
    public float tempoGeradorZumbi = 1;
    public LayerMask layerZumbi;
    private float distanciaGeracao = 3f;
    private float distanciaJogadorGeracao = 20f;
    private GameObject jogador;
    private void Start()
    {
        jogador = GameObject.FindWithTag(Tags.jogador);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, jogador.transform.position) > distanciaJogadorGeracao)
        {
            contadorTempo += Time.deltaTime;
            if (contadorTempo >= tempoGeradorZumbi)
            {
                StartCoroutine(gerarZumbi());
                contadorTempo = 0;
            }
        }
          
    }
    IEnumerator gerarZumbi()
    {
        Vector3 posicao = aleatorizarPosicao();
        Collider[] colisores = Physics.OverlapSphere(posicao, 1, layerZumbi);

        while (colisores.Length > 0)
        {
            posicao = aleatorizarPosicao();
            colisores = Physics.OverlapSphere(posicao, 1, layerZumbi);
            yield return null;
        }
        Instantiate(zumbi, posicao, transform.rotation);            
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaGeracao);
    }

    Vector3 aleatorizarPosicao()
    {
        Vector3 posicao = Random.insideUnitSphere * distanciaGeracao;
        posicao += transform.position;
        posicao.y = 0;
        return posicao;
    }
}
