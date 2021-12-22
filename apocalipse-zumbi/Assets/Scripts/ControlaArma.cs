using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public GameObject bala;
    public GameObject canoArma;
    public AudioClip somTiro;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bala, canoArma.transform.position, canoArma.transform.rotation);
            ControlaAudio.instance.PlayOneShot(somTiro);
        }
    }
}
