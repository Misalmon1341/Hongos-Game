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

    private new Shot shot;
    void Awake()
    {
        durabilidad = 30;
        shot = GetComponent<Shot>();
        takeGuns = GetComponent<TakeGuns>();
    }
    private float tiempoUltimoDisparo;
    public override void Usar()
    {
        if (durabilidad <= 0) return;

        if (shot != null)
        {
            StartCoroutine(shot.DispararConDelay(0.3f));
            durabilidad--;
        }

        if (durabilidad <= 0)
        {
            takeGuns.DesactivarArmas();
        }
    }
    public override void UsarHabilidad()
    {
        if (durabilidad <= 0) return;

        // Instanciar y lanzar la bomba
        GameObject bomba = Instantiate(bombaPrefab, spawnPointBomba.position, Quaternion.identity);

        Rigidbody rb = bomba.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direccion = transform.forward;
            rb.velocity = direccion * fuerzaLanzamiento;
        }

        // Reproduce animación
        if (shot != null)
        {
            StartCoroutine(shot.DispararConDelay(0.3f));
        }

        durabilidad = 0;
        takeGuns.DesactivarArmas();
    }
}
