using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeArmaController : MonoBehaviour
{
    public bool uzi;
    public bool m48;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (uzi)
            {
                other.GetComponent<FPS_Controlador>().fps_disparo.UseUZI();
            }else if (m48)
            {
                other.GetComponent<FPS_Controlador>().fps_disparo.UseM48();
            }
        }
    }
}
