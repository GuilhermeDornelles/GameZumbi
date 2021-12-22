using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeZumbi : MonoBehaviour
{
    public GameObject zumbi;
    float contadorTempo = 0;
    public float tempoGeradorZumbi = 1;   
    // Update is called once per frame
    void Update()
    {
        contadorTempo += Time.deltaTime;
        if(contadorTempo >= tempoGeradorZumbi)
        {
            Instantiate(zumbi, transform.position, transform.rotation);
            contadorTempo = 0;
        }        
    }
}
