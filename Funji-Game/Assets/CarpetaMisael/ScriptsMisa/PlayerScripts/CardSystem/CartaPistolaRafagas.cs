using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CartaPistolaRafagas : CartaBase
{

    [Header("Disparo Ráfaga")]
    public GameObject balaPrefab;
    public Transform spawnPoint;
    public float velocidadBala = 10f;
    public float cooldown = 1f;
    [Header("Efecto visual del salto")]
    public GameObject saltoExtraEfectoPrefab;
    public Transform puntoSpawnEfecto;

    private float tiempoUltimoDisparo;

    public override void Usar()
    {
        if (durabilidad <= 0 || Time.time < tiempoUltimoDisparo + cooldown) return;

        tiempoUltimoDisparo = Time.time;
        movPersonaje.estaDisparando = true;

        // Animación
        DisparoHelper.EjecutarAnimacionDisparo(movPersonaje.Animator);

        // Dispara las 3 balas con tiempo entre cada una
        StartCoroutine(DispararRafaga());

        durabilidad--;
        if (durabilidad <= 0)
        {
            Descartar();
        }
    }

    private IEnumerator DispararRafaga()
    {
        int cantidadBalas = 3;
        float tiempoEntreBalas = 0.1f;

        for (int i = 0; i < cantidadBalas; i++)
        {
            DispararBala();
            yield return new WaitForSeconds(tiempoEntreBalas);
        }

        movPersonaje.estaDisparando = false;
    }

    private void DispararBala()
    {
        GameObject bala = Instantiate(balaPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(movPersonaje.transform.forward.x, 0, 0) * velocidadBala;
    }

    public override void UsarHabilidad()
    {
        if (durabilidad <= 0 || !movPersonaje.EnElAire) return;

        // Activar el salto doble
        movPersonaje.Salto();
        movPersonaje.ActivarSaltoDoble();

        // Instanciar el efecto visual si existe
        if (saltoExtraEfectoPrefab != null && puntoSpawnEfecto != null)
        {
            Instantiate(saltoExtraEfectoPrefab, puntoSpawnEfecto.position, Quaternion.identity);
        }

        durabilidad = 0;
        Descartar();
    }

}
