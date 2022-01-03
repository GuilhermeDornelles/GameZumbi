using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour
{
    public float velocidade = 1f;
    private Rigidbody rigidbodyBala;
    public AudioClip somMorte;
    private int danoTiro = 1;

    private void Start()
    {
        rigidbodyBala = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbodyBala.MovePosition(rigidbodyBala.position + transform.forward * velocidade * Time.deltaTime) ;
    }

    private void OnTriggerEnter(Collider objetoColisao)
    {
        if(objetoColisao.tag == "Inimigo")
        {
            objetoColisao.GetComponent<ControlaZumbi>().tomarDano(danoTiro);
        } 
            Destroy(gameObject);        
    }
}
