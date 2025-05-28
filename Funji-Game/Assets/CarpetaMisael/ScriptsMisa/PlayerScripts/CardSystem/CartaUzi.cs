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

        DisparoHelper.EjecutarAnimacionDisparo(movPersonaje.Animator);
        DisparoHelper.DispararBala(balaPrefab, spawnPoint, velocidadBala);

        durabilidad--;
        if (durabilidad <= 0)
        {
            Descartar();
        }
    }

    public override void UsarHabilidad()
    {
        if (durabilidad <= 0) return;

        DisparoHelper.EjecutarAnimacionDisparo(movPersonaje.Animator);

        StartCoroutine(LanzarBomba());
        GameObject bomba = Instantiate(bombaPrefab, spawnPoint.position, Quaternion.identity);
        bomba.GetComponent<Rigidbody>().AddForce(spawnPoint.right * fuerzaBomba, ForceMode.Impulse);

        durabilidad = 0;
        Descartar();
    }
    IEnumerator LanzarBomba()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Se esta ejecutando la corrutina de la bomba");
    }
}
