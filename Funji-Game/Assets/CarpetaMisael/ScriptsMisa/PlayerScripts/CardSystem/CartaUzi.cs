using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaUzi : CartaBase
{
    [Header("Disparo")]
    public GameObject balaPrefab;
    public Transform spawnPoint;
    public float velocidadBala = 12f;

    [Header("Bomba")]
    public GameObject bombaPrefab;
    public float fuerzaBomba = 15f;

    public override void Usar()
    {
        if (durabilidad <= 0) return;

        DisparoHelper.EjecutarAnimacionDisparo(anim);
        DisparoHelper.DispararBala(balaPrefab, spawnPoint, velocidadBala);

        durabilidad--;
        if (durabilidad <= 0)
            takeGuns.DesactivarArmas();
    }

    public override void UsarHabilidad()
    {
        if (durabilidad <= 0) return;

        DisparoHelper.EjecutarAnimacionDisparo(anim);

        GameObject bomba = Instantiate(bombaPrefab, spawnPoint.position, Quaternion.identity);
        bomba.GetComponent<Rigidbody>().AddForce(spawnPoint.right * fuerzaBomba, ForceMode.Impulse);

        durabilidad = 0;
        takeGuns.DesactivarArmas();
    }
}
