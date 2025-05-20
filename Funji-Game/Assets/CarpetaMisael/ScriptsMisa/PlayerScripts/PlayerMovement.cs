using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float rapidezMovimiento;
    public static bool miraDerecha;

    [Header("Salto")]
    public float jumpf;
    [SerializeField] private bool dobleSaltoActivo;
    private int contadorDobleSalto;

    [Header("Coyote")]
    public float coyoteTime;
    public float coyoteTimeCounter;

    [Header("Buffer")]
    public float bufferTime;
    public float bufferTimeCounter;

    private bool tocarSuelo;
    private bool yaSalto;
    private Rigidbody rB;

    [Header("DobleSalto")]
    [SerializeField] private int SaltosExtraRestantes;
    [SerializeField] private int saltosExtra;
    private void Awake()
    {
        rB = GetComponent<Rigidbody>();
        tocarSuelo = false;
    }

    private void Update()
    {
        MovimientoLateral();
        Salto();
        BufferManager();
    }
    private void MovimientoLateral() 
    {
        float moveInput = Input.GetAxis("Horizontal");
        rB.velocity = new Vector3(moveInput * rapidezMovimiento, rB.velocity.y, 0);
        if (moveInput == 0) return;
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-6, 6, 0);
            miraDerecha = false;
            return;
        }
        transform.localScale = new Vector3(6, 6, 0);
        miraDerecha = true;
    }

    private void Salto()
    {
        CoyoteTimeManager();
        {
            if (bufferTimeCounter > 0 && !yaSalto && coyoteTimeCounter > 0)
            {
                yaSalto = false;
                rB.velocity = new Vector3(rB.velocity.x, 1 * jumpf, 0);
            }
            else if (bufferTimeCounter > 0 && contadorDobleSalto > 0 && dobleSaltoActivo) 
            {
                rB.velocity = new Vector3(rB.velocity.x, 1 * jumpf, 0);
                contadorDobleSalto--; 
            }


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            tocarSuelo = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            tocarSuelo = false;
        }
    }

    private void CoyoteTimeManager()
    {
        if (tocarSuelo)
        {
            yaSalto = false;
            coyoteTimeCounter = coyoteTime;
            contadorDobleSalto = dobleSaltoActivo ? 1 : 0;
            return;
        }
        coyoteTimeCounter -= Time.deltaTime;
    }

    private void BufferManager()
    {
        if (Input.GetButtonDown("Jump"))
        {
            bufferTimeCounter = bufferTime;
            return;
        }
        bufferTimeCounter -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("DobleSalto"))
        {
            dobleSaltoActivo = true;
            other.gameObject.SetActive(false);
        }
    }
}

