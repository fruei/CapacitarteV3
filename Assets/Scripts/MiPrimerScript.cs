using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MiPrimerScript : MonoBehaviour
{
    // tipoDeAcceso  tipoDelDato  nombreDelContenedorOVariable  puntoYComa
    public string cajitaDePalabras; // string => texto
    public int cajitaDeNumEnteros; // int => numeros enteros
    public float cajitaDeNumDecimales; // float => numeros decimales
    
    // tipoDeAcceso 'void' nombreDelMetodo  ()  { ...codigo... } 
    private void Start()
    {
        // Debug.LogError("hola soy un error");
        // Debug.Log("HOLA MUNDO");
        // Debug.LogWarning("soy una advertencia");

         MiPrimerMetodo();
    }
    
    private void Update()
    {
        //Debug.LogWarning("contador");
    }

    public void MiPrimerMetodo()
    {
        Debug.Log("Mi primer metodo se ejecuto desde el Start");
    }
}