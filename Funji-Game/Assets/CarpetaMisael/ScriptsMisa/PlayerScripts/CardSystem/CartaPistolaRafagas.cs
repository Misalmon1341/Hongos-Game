using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CartaPistolaRafagas : CartaBase
{

    public GameObject balaPrefab;
    public Transform spawnPoint;
    public float velocidadBala = 12f;
    public float intervaloEntreBalas = 0.1f;

    private bool disparando = false;

    public override void EjecutarDisparo()
    {
        if (!disparando)
            StartCoroutine(DispararRafaga());
    }

    IEnumerator DispararRafaga()
    {
        disparando = true;

        for (int i = 0; i < 3; i++)
        {
            GameObject bala = Instantiate(balaPrefab, spawnPoint.position, Quaternion.identity);
            bala.GetComponent<Rigidbody>().velocity = transform.forward * velocidadBala;
            yield return new WaitForSeconds(intervaloEntreBalas);
        }

        durabilidad--;

        if (durabilidad <= 0)
        {
            takeGuns.DesactivarArmas();
        }

        yield return new WaitForSeconds(cooldownDisparo);
        disparando = false;
    }

    public override void UsarHabilidad()
    {
        MovPersonaje mov = GetComponentInParent<MovPersonaje>();

        if (!mov.GetComponent<CharacterController>().isGrounded)
        {
            mov.Salto(); // Reutiliza tu función de salto ya implementada
            durabilidad = 0;
            takeGuns.DesactivarArmas();
        }
    }
}
