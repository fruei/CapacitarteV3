using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo_Controlador : MonoBehaviour
{
    public NavMeshAgent nav;

    public Transform jugador;
    public float minDistPerseguir;
    public bool perseguir = false;
    public float perseguirSpeed;

    public Transform puntoA;
    public Transform puntoB;

    [SerializeField]
    private Transform puntoObjetivo;
    public float distMinPatrullaje;
    public float patrullarSpeed;

    public Animator anim;

    public float distMinAtacar;
    public float distMaxAtacar;
    public bool atacando = false;

    private void Start()
    {
        puntoObjetivo = puntoA;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, jugador.position);

        if (distance <= minDistPerseguir)
            perseguir = true;

        if (distance <= distMinAtacar)
            atacando = true;
        if (distance >= distMaxAtacar)
            atacando = false;

        if (perseguir && !atacando)
        {
            anim.SetBool("pers", true);
            anim.SetBool("atacando", false);
            
            nav.speed = perseguirSpeed;
            
            nav.SetDestination(jugador.position);
        }else if (atacando)
        {
            anim.SetBool("atacando", true);
        }
        else
        {
            anim.SetBool("atacando", false);
            anim.SetBool("pers", false);
            PatrullajeAI();
        }
    }

    public void PatrullajeAI()
    {
        float distance = Vector3.Distance(transform.position, puntoObjetivo.position);
        
        nav.speed = patrullarSpeed;
        
        if (distance <= distMinPatrullaje)
        {
            if (puntoObjetivo == puntoA)
                puntoObjetivo = puntoB;
            else
                puntoObjetivo = puntoA;
        }

        nav.SetDestination(puntoObjetivo.position);
    }
}
