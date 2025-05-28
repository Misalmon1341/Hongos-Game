using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaEscopeta : CartaBase
{

    [Header("Disparo")]
    public GameObject perdigonPrefab;
    public Transform spawnPoint;
    public float velocidadPerdigon = 10f;
    public int cantidadPerdigones = 5;
    public float anguloDispersion = 50f;
    private bool habilidadUsada = false;

    [Header("RompeParedes")]
    public GameObject perdigonPrefab2;
    public Transform spawnPoint2;
    public float velocidadPerdigon2 = 10f;
    public int cantidadPerdigones2 = 5;
    public float anguloDispersion2 = 50f;

    public override void Usar()
    {
        if (durabilidad <= 0) return;


        DisparoHelper.EjecutarAnimacionDisparo(movPersonaje.Animator);

        Vector3 direccionBase = movPersonaje.transform.forward; 
        float inicioAngulo = -anguloDispersion / 2f;
        float incremento = anguloDispersion / (cantidadPerdigones - 1f);

        for (int i = 0; i < cantidadPerdigones; i++)
        {
            float angulo = inicioAngulo + incremento * i;
            Quaternion rotacionDisparo = Quaternion.AngleAxis(angulo, Vector3.up); 

            Vector3 direccionDisparo = rotacionDisparo * direccionBase;

            GameObject perdigon = Instantiate(perdigonPrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody rb = perdigon.GetComponent<Rigidbody>();
            rb.velocity = direccionDisparo.normalized * velocidadPerdigon;
        }



        durabilidad--;
        if (durabilidad <= 0) Descartar();
    }

    public override void UsarHabilidad()
    {
        if (durabilidad <= 0) return;

        DisparoHelper.EjecutarAnimacionDisparo(movPersonaje.Animator);

        Vector3 direccionBase = movPersonaje.transform.forward;
        float inicioAngulo = -anguloDispersion2 / 2f;
        float incremento = cantidadPerdigones2 > 1 ? anguloDispersion2 / (cantidadPerdigones2 - 1) : 0;

        List<Collider> perdigonColliders = new List<Collider>();

        for (int i = 0; i < cantidadPerdigones2; i++)
        {
            float angulo = inicioAngulo + incremento * i;
            Quaternion rotacionDisparo = Quaternion.AngleAxis(angulo, Vector3.up);
            Vector3 direccionDisparo = rotacionDisparo * direccionBase;

            GameObject perdigon = Instantiate(perdigonPrefab2, spawnPoint2.position, Quaternion.LookRotation(direccionDisparo));

            // Asignar capa adecuada
            perdigon.layer = LayerMask.NameToLayer("Perdigon");

            // Ignorar colisión con el jugador
            Collider jugadorCollider = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Collider>();
            Collider perdigonCollider = perdigon.GetComponent<Collider>();
            if (jugadorCollider != null && perdigonCollider != null)
            {
                Physics.IgnoreCollision(perdigonCollider, jugadorCollider);
            }

            // Ignorar colisión con el spawn point si tiene collider
            Collider spawnCollider = spawnPoint2.GetComponent<Collider>();
            if (spawnCollider != null && perdigonCollider != null)
            {
                Physics.IgnoreCollision(perdigonCollider, spawnCollider);
            }

            // Guardar collider para ignorar entre perdigones
            if (perdigonCollider != null)
            {
                foreach (var other in perdigonColliders)
                {
                    Physics.IgnoreCollision(perdigonCollider, other);
                }
                perdigonColliders.Add(perdigonCollider);
            }

            // Aplicar fuerza
            Rigidbody rb = perdigon.GetComponent<Rigidbody>();
            rb.velocity = direccionDisparo.normalized * velocidadPerdigon2;
        }

        durabilidad--;
        if (durabilidad <= 0) Descartar();


    }
}