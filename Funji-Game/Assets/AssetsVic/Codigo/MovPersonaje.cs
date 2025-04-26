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
    private float rotacionPersonaje;
    private string direccion = "Derecha";
    private CharacterController controlPersonaje;
    private Vector3 movimiento;
    [Header("Gravedad")]
    [SerializeField] private float gravedad;
    [Header("Salto")]
    private float FuerzaSalto = 5f;
    private bool enElAire = false;
    [Header("SaltoDoble")]
    private bool saltoDoble = false;

    // Start is called before the first frame update
    void Start()
    {
        animacion = this.GetComponent<Animator>();
        controlPersonaje = this.GetComponent<CharacterController>();
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
        if (hInput > 0)
        {
            if (direccion == "Izquierda")
            {
                rotacionPersonaje = -180f;
                this.transform.Rotate(Vector3.up, rotacionPersonaje);
                direccion = "Derecha";
            }
            animacion.SetBool(name: "Running", value: true);
            controlPersonaje.SimpleMove(movimiento);
            return;
        }
        if(hInput < 0)
        {
            if (direccion == "Derecha")
            {
                rotacionPersonaje = 180f;
                this.transform.Rotate(Vector3.up,rotacionPersonaje);
                direccion = "Izquierda";
            }
            animacion.SetBool(name:"Running",value:true);
            controlPersonaje.SimpleMove(movimiento);
            return;
        }

        animacion.SetBool("Running", false);
        
    }
}
