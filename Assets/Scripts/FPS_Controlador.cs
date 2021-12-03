using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class FPS_Controlador : MonoBehaviour
{
    public Camera camara;

    public float rotVertMin;
    public float rotVertMax;
    public float sensibilidadMouse;

    float _camMovVertical;
    float _camMovHorizontal;

    public CharacterController characterController;

    float _movVertical;
    float _movHorizontal;

    public float correrVelocidad;
    public float caminarVelocidad = 4f;

    public Vector3 _velocidad;

    public float gravedad;

    public float fuerzaDeSalto;

    public Transform piesTransform;

    public float radioPiesColision;

    public LayerMask layerPiso;

    public bool sobreLaTierra;

    public FPS_Disparo fps_disparo;

    void Update()
    {
        RotacionDeCamara();

        MovimientoDelPersonaje();
    }

    void MovimientoDelPersonaje()
    {
        _movVertical = Input.GetAxis("Vertical");
        _movHorizontal = Input.GetAxis("Horizontal");

        float velocidadActual = 0f;

        if (Input.GetKey(KeyCode.LeftShift))
            velocidadActual = correrVelocidad;
        else
            velocidadActual = caminarVelocidad;
        
        Vector3 movimiento =
            transform.right * _movHorizontal +
            transform.forward * _movVertical;
        characterController.Move(movimiento * Time.deltaTime * velocidadActual);

        sobreLaTierra = Physics.CheckSphere(piesTransform.position, radioPiesColision, layerPiso);
        
        if ( Input.GetKey(KeyCode.Space) && sobreLaTierra ) 
            _velocidad.y = Mathf.Sqrt(fuerzaDeSalto * -2f * gravedad);
        
        _velocidad.y += gravedad * Time.deltaTime;

        characterController.Move(_velocidad * Time.deltaTime);
    }
    
    void RotacionDeCamara()
    {
        _camMovVertical += Input.GetAxis("Mouse Y") * sensibilidadMouse;

        _camMovVertical = Mathf.Clamp(_camMovVertical, rotVertMin, rotVertMax);

        camara.transform.localRotation = Quaternion.Euler(-_camMovVertical,0f,0f);
        
        _camMovHorizontal = Input.GetAxis("Mouse X") * sensibilidadMouse;
        
        transform.Rotate(0f, _camMovHorizontal, 0f);
    }
}
