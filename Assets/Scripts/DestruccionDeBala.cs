using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestruccionDeBala : MonoBehaviour
{
    public float tiempoDeDestruccion;
    float _time = 0f;

    private void Update()
    {
        _time += Time.deltaTime;
        
        if ( _time >= tiempoDeDestruccion )
        {
            Destroy( gameObject );
        }

    }
}
