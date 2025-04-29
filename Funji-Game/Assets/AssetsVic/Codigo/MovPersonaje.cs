using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    [Header("Personaje")]
    private Animator animacion;
    public float velocidad = 1.5f;
    private float hInput;
    private Quaternion rotacionPersonaje;
    private CharacterController controlPersonaje;
    private Vector3 movimiento;
    [Header("Gravedad")]
    private float gravedad = 9.8f;
    [Header("Salto")]
    private float fuerzaSalto = 4f;
    private bool enElAire = false;
    [Header("SaltoDoble")]
    private bool saltoDoble = false;
    [Header("Dash")]
    private float velocidadDash = 7f;
    private float duracionDash = 0.15f;
    private bool dashActivo = false;
    [Header("Coyote")]
    private bool coyoteActivo = true;
    private float tiempoCoyote = 0;
    private float duracionCoyoteTime = 0.05f;
    [Header("Buffer")]
    private float tiempoBufferSalto = 0f;
    private float duracionBufferSalto = 0.1f;
    [Header("WallJump")]
    private bool enLaPared = false;
    private Vector3 posicionRayCast;
    private float centradoRayCast = 0.5f;
    public LayerMask ParedLayerMask;
    private float saltoParedLateral = 18f;
    private float separacionParedSalto = 2.5f;

    void Start()
    {
        animacion = this.GetComponent<Animator>();
        controlPersonaje = this.GetComponent<CharacterController>();
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        moverPersonaje();

    }
    void moverPersonaje()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        if (!enLaPared)
        {
            movimiento.x = hInput * velocidad;
        }
        if (controlPersonaje.isGrounded)
        {
            saltoDoble = false;
            enElAire = false ;
            dashActivo = false;
            enLaPared = false ;
            coyoteActivo= true;
            animacion.SetBool("Jumping", false);
            animacion.SetBool("Running", false);
            animacion.SetBool("Dash", false);
            animacion.SetBool("Pared", false);
            if (tiempoBufferSalto > 0)
            {
                Salto();
            }
        }
        else
        {
             enElAire = true;
            ComprobarColisionPared();
            if (coyoteActivo)
            {
                coyoteActivo = false;
                tiempoCoyote = Time.time;
                movimiento.y = 0;
            }
            if  (tiempoCoyote + duracionCoyoteTime < Time.time)
            {
                if (saltoDoble && Input.GetButtonDown("Jump"))
                {
                    saltoDoble = false;
                    movimiento.y = fuerzaSalto;
                }
                if(!saltoDoble && Input.GetButtonDown("Jump"))
                {
                    tiempoBufferSalto = duracionBufferSalto;
                }
                animacion.SetBool("Dash", false);
                tiempoBufferSalto -= Time.deltaTime;
                movimiento.y -= gravedad * Time.deltaTime;
            } 
        }

        if (hInput != 0)
        {
            rotacionPersonaje = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            this.transform.rotation = rotacionPersonaje;
            animacion.SetBool("Running", true);

        }
        if (Input.GetButtonDown("Jump") && !enElAire)
        {
            Salto();
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt) && !dashActivo)
        {
            StartCoroutine(Dash());
        }
        controlPersonaje.Move(movimiento * Time.deltaTime);
    }
    IEnumerator Dash()
    {
        float tiempoInicial = Time.time;
        dashActivo = true;
       
        while (Time.time < tiempoInicial + duracionDash)
        {
            animacion.SetBool("Dash", true);
            movimiento = this.transform.TransformDirection(Vector3.forward * velocidadDash);
            movimiento.y = 0;
            controlPersonaje.Move(movimiento * Time.deltaTime);
            yield return null;
        }
    }
    void Salto()
    {
        ComprobarColisionPared();
        enElAire = true;
        saltoDoble = true;
        coyoteActivo = false;
        if (enLaPared)
        {
            rotacionPersonaje = Quaternion.LookRotation(this.transform.TransformDirection(Vector3.forward * -1));
            this.transform.rotation = rotacionPersonaje;
            movimiento = this.transform.TransformDirection(Vector3.forward * saltoParedLateral * velocidad);
        }
        enLaPared = false;
        animacion.SetBool("Pared", false);
        tiempoCoyote -= duracionCoyoteTime;
        animacion.SetBool("Jumping", true);
        movimiento.y = fuerzaSalto;
        tiempoBufferSalto = 0f;
    }
    void ComprobarColisionPared()
    {
        float longitudRaycast = 0.3f;
        posicionRayCast = this.transform.position;
        posicionRayCast.y += centradoRayCast;
        if (Physics.Raycast(posicionRayCast,this.transform.TransformDirection(Vector3.forward), longitudRaycast,ParedLayerMask))
        {
            if (controlPersonaje.isGrounded)
            {
                movimiento = this.transform.TransformDirection(Vector3.forward) * separacionParedSalto * velocidad * -1;
            }
            else
            {
                animacion.SetBool("Jumping", false);
                animacion.SetBool("Running", false);
                animacion.SetBool("Pared", true);
                if (!enLaPared)
                {
                    movimiento.y = 0;
                }
                enLaPared = true;
                enElAire = false;
                gravedad = 1.8f;
            }
        }
        else
        {
            enLaPared = false;
            animacion.SetBool("Pared", false);
            gravedad = 9.8f;
        }

    }
}
