using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInterface : MonoBehaviour
{
    private ControlaJogador scriptJogador;
    public Slider sliderVidaJogador;
    public GameObject painelGameOver;
    public Text textoTempoSobrev;
    public Text textoTotalSobrev;
    private float tempoMaximo;

    // Start is called before the first frame update
    void Start()
    {
        scriptJogador = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();
        sliderVidaJogador.maxValue = scriptJogador.statusJogador.vida;
        atualizarSliderVidaJogador();
        Time.timeScale = 1;
        tempoMaximo = PlayerPrefs.GetFloat("PontuacaoMaxima", tempoMaximo);
    }   

    public void atualizarSliderVidaJogador()
    {
        sliderVidaJogador.value = scriptJogador.statusJogador.vida;
    }

    public void GameOver()
    {       
        painelGameOver.SetActive(true);
        Time.timeScale = 0;

        int minutos = (int)Time.timeSinceLevelLoad/60;
        int segundos = (int)Time.timeSinceLevelLoad % 60;
        textoTempoSobrev.text = "Você sobreviveu por " + minutos + " minuto(s) e " + segundos + " segundo(s)!";
        ajustarPontMax(minutos, segundos);
    }

    void ajustarPontMax(int minutos, int segundos)
    {
        if(Time.timeSinceLevelLoad > tempoMaximo)
        {
            tempoMaximo = Time.timeSinceLevelLoad;
            //outra forma de criar strings
            textoTotalSobrev.text = string.Format("Seu melhor tempo é {0} minuto(s) e {1} segundo(s)", minutos, segundos);
            PlayerPrefs.SetFloat("PontuacaoMaxima", tempoMaximo);
        }
        if(textoTotalSobrev.text == "")
        {
            minutos = (int)tempoMaximo / 60;
            segundos = (int)tempoMaximo % 60;
            textoTotalSobrev.text = string.Format("Seu melhor tempo é {0} minuto(s) e {1} segundo(s)", minutos, segundos);
        }
    }

    public void reiniciar()
    {
        SceneManager.LoadScene("game");
    }
}
