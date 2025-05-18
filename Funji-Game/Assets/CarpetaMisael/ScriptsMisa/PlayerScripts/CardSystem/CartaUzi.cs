using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaUzi : CartaBase
{
    [Header("Disparo")]
    public GameObject balaPrefab;
    public Transform spawnPoint;
    public float velocidadBala = 10f;
    public float cooldown = 0.3f;
  

    [Header("Habilidad - Bomba")]
    public GameObject bombaPrefab;
    public Transform spawnPointBomba;
    public float fuerzaLanzamiento = 15f;
    public TakeGuns takeGuns;
    public int indexCarta;

    void Awake()
    {
        durabilidad = 30;
    }
    private float tiempoUltimoDisparo;
    public override void EjecutarDisparo()
    {
        if (Time.time - tiempoUltimoDisparo < cooldown || durabilidad <= 0) return;

        GameObject bala = Instantiate(balaPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * velocidadBala;

        durabilidad--;
        tiempoUltimoDisparo = Time.time;

        if (durabilidad <= 0)
        {
            takeGuns.DesactivarArmas();
        }
    }
    public override void UsarHabilidad()
    {
        GameObject bomba = Instantiate(bombaPrefab, spawnPointBomba.position, Quaternion.identity);
        Rigidbody rb = bomba.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * fuerzaLanzamiento, ForceMode.VelocityChange);

        takeGuns.DesactivarArmas();
    }
}
