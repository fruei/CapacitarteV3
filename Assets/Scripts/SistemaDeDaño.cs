using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDeDaño : MonoBehaviour
{
    public float daño;
    public bool unSoloUso;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Enemigo"))
        {
            SistemaDeVida vidaDelObjetivo = collisionInfo.gameObject.GetComponent<SistemaDeVida>();
            AplicarDaño(vidaDelObjetivo);
        }
    }

    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.CompareTag("Enemigo"))
        {
            SistemaDeVida vidaDelObjetivo = collisionInfo.GetComponent<SistemaDeVida>();
            AplicarDaño(vidaDelObjetivo);
        }
        
        if (collisionInfo.CompareTag("Player"))
        {
            SistemaDeVida vidaDelObjetivo = collisionInfo.GetComponent<SistemaDeVida>();
            vidaDelObjetivo.vidaActual -= daño;
        }
    }

    private void AplicarDaño(SistemaDeVida _vidaDelObjetivo)
    {
        _vidaDelObjetivo.vidaActual -= daño;
        if(unSoloUso)
            Destroy(gameObject);
    }
}
