using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sonido
{
    public string name;
    
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    
    [Range(.1f,3f)]
    public float pitch;

    public bool loop;

    public AudioSource source;
}
