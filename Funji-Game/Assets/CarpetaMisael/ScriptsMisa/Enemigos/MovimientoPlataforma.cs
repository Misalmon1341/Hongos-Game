using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    [SerializeField] private float velocidad = 2f;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia = 1f;
    [SerializeField] private bool moviendoDerecha = true;
    [SerializeField] private LayerMask capaSuelo;  
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }

    private void FixedUpdate()
    {
        Vector3 direccion = moviendoDerecha ? Vector3.right : Vector3.left;
        rb.velocity = new Vector3(direccion.x * velocidad, rb.velocity.y, 0);

        bool haySuelo = Physics.Raycast(controladorSuelo.position, Vector3.down, distancia, capaSuelo);
        if (!haySuelo)
        {
            Girar();
        }
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        if (controladorSuelo != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(controladorSuelo.position, controladorSuelo.position + Vector3.down * distancia);
        }
    }
}
