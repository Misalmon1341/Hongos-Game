using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    [Header("Personaje")]
    private Animator animacion;
    private float velocidad = 1.5f;
    private float hInput;
    private Quaternion rotacionPersonaje;
    private CharacterController controlPersonaje;
    private Vector3 movimiento;
    [Header("Gravedad")]
    private float gravedad = 0.3f;
    [Header("Salto")]
    private float FuerzaSalto = 5f;
    private bool enElAire = false;
    [Header("SaltoDoble")]
    private bool saltoDoble = false;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        controlPersonaje = GetComponent<CharacterController>();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        moverPersonaje();

    }
    void moverPersonaje()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        movimiento.x = hInput * velocidad;
        if (controlPersonaje.isGrounded)
        {
            enElAire = false;
            saltoDoble = true;
            animacion.SetBool(name: "Saltando", value: false);
            animacion.SetBool(name: "Caminando", value: false);
        }
        else
        {
            if (saltoDoble && Input.GetButtonDown("Jump"))
            {
                saltoDoble=false;
                movimiento.y = FuerzaSalto;
            }
            movimiento.y -= gravedad;
        }
        if (hInput != 0)
        {
            rotacionPersonaje = Quaternion.LookRotation(new Vector3(x:hInput, y: 0, z: 0));
            this.transform.rotation = rotacionPersonaje;
            animacion.SetBool(name: "Caminando", value: true);
        } 
        if (Input.GetButtonDown("Jump")&& !enElAire)
        {
            enElAire= true; 
            animacion.SetBool(name:"Saltando",value:true);
            movimiento.y = FuerzaSalto;
        }
        controlPersonaje.Move(motion: movimiento * Time.deltaTime);
    }
}
