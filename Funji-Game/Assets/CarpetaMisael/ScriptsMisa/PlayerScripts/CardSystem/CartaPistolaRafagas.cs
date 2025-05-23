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

    [Header("Jugador")]
    public MovPersonaje jugador; // Asigna este en el Inspector

    private float tiempoUltimoDisparo;

    void Awake()
    {
        durabilidad = 10;
        takeGuns = GetComponent<TakeGuns>();
    }

    public override void Usar()
    {
        if (durabilidad <= 0 || Time.time < tiempoUltimoDisparo + cooldown) return;

        tiempoUltimoDisparo = Time.time;
        jugador.animacion.SetTrigger("Shoot");
        jugador.estaDisparando = true;

        // Dispara 3 balas en ráfaga
        for (int i = 0; i < 3; i++)
        {
            GameObject bala = Instantiate(balaPrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(jugador.transform.forward.x, 0, 0) * velocidadBala;
        }

        durabilidad--;
        if (durabilidad <= 0) takeGuns.DesactivarArmas();
    }

    public override void UsarHabilidad()
    {
        if (durabilidad <= 0) return;

        jugador.ActivarSaltoDoble();
        jugador.animacion.SetTrigger("Shoot");
        jugador.estaDisparando = true;

        durabilidad = 0;
        takeGuns.DesactivarArmas();
    }
}
