using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public Sonido[] sonidos;
    public string audioInicial;

    public static AudioController principal;

    private void Awake()
    {
        if (principal == null)
        {
            principal = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sonido s in sonidos)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Reproducir(audioInicial);
    }

    public void Reproducir(string name)
    {
        Sonido _sonido = Array.Find(sonidos, s => s.name == name );

        if (_sonido == null)
            return;
        
        _sonido.source.Play();
    }
}
