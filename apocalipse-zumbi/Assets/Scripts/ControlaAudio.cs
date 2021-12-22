using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public static AudioSource instance; //Static pra funcionar em qualquer objeto

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        instance = audioSource;
    }
}
