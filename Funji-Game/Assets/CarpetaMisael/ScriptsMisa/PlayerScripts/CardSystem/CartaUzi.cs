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
    [SerializeField] protected new TakeGuns takeGuns;

    [Header("Habilidad - Bomba")]
    public GameObject bombaPrefab;
    public Transform spawnPointBomba;
    public float fuerzaLanzamiento = 15f;

    private new Shot shot;
    void Awake()
    {
        durabilidad = 30;
        shot = GetComponent<Shot>();
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

        // Instanciar bomba
        Instantiate(bombaPrefab, spawnPoint.position, Quaternion.identity);

        // Reproduce animación
        if (shot != null)
        {
            StartCoroutine(shot.DispararConDelay(0.3f));
        }

        durabilidad = 0;
        takeGuns.DesactivarArmas();
    }
}
