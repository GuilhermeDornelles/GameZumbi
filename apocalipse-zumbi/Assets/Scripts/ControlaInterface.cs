using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaInterface : MonoBehaviour
{
    private ControlaJogador scriptJogador;
    public Slider sliderVidaJogador;

    // Start is called before the first frame update
    void Start()
    {
        scriptJogador = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();
        sliderVidaJogador.maxValue = scriptJogador.vida;
        atualizarSliderVidaJogador();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void atualizarSliderVidaJogador()
    {
        sliderVidaJogador.value = scriptJogador.vida;
    }
}
