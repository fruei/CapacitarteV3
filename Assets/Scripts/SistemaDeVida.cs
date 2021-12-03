using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SistemaDeVida : MonoBehaviour
{
    public float vidaActual = 100f;
    private void Update()
    {
        if (vidaActual <= 0) // Cuando la vida llegue a 0
        {
            if(gameObject.CompareTag("Enemigo"))
                GameController.main.enemyKilledCount++;
            
            Destroy( gameObject ); // AutoDestruccion al instante
        }
    }
}
