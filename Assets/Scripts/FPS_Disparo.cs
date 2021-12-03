using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Disparo : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform armaPivot;
    public float fuerzaDeDisparo;

    public float rateTimeDisparo;
    [SerializeField]
    private float _time = 0f;

    public GameObject uzi;
    public GameObject m48;

    public float uziFuerzaDeDisparo;
    public float uziRateTimeDisparo;

    public float m48FuerzaDeDisparo;
    public float m48RateTimeDeDisparo;
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        _time += Time.deltaTime;
        
        if (Input.GetMouseButton(0) && _time >= rateTimeDisparo )
        {
            AudioController.principal.Reproducir("Laser");
            
            _time = 0f;
            GameObject balaTemporal = Instantiate(balaPrefab, armaPivot.position, Quaternion.identity);
            
            Rigidbody balaRigidbody =  balaTemporal.GetComponent<Rigidbody>();
            
            balaRigidbody.AddForce(armaPivot.transform.forward * fuerzaDeDisparo, ForceMode.Impulse);
        }
    }

    public void UseUZI()
    {
        uzi.SetActive(true);
        m48.SetActive(false);
        
        fuerzaDeDisparo = uziFuerzaDeDisparo;
        rateTimeDisparo = uziRateTimeDisparo;
    }

    public void UseM48()
    {
        uzi.SetActive(false);
        m48.SetActive(true);
        
        fuerzaDeDisparo = m48FuerzaDeDisparo;
        rateTimeDisparo = m48RateTimeDeDisparo;
    }
}
