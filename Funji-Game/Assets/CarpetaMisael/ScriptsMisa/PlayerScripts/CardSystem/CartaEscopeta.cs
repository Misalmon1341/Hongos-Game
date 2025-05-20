using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaEscopeta : CartaBase
{
    public GameObject perdigonPrefab;
    public Transform spawnPoint;
    public float dispersion = 8f;
    public float fuerzaDisparo = 10f;
    [SerializeField] protected new TakeGuns takeGuns;
    public override void EjecutarDisparo()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 direccion = spawnPoint.forward;
         
            direccion.x += Random.Range(-dispersion, dispersion) * 0.01f;
            direccion.y += Random.Range(-dispersion, dispersion) * 0.01f;

            GameObject perdigon = Instantiate(perdigonPrefab, spawnPoint.position, Quaternion.LookRotation(direccion));
            perdigon.GetComponent<Rigidbody>().velocity = direccion.normalized * fuerzaDisparo;
        }
    }

    public override void UsarHabilidad()
    {
        Ray ray = new Ray(spawnPoint.position, spawnPoint.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 20f)) // Rango del rayo
        {
            if (hit.collider.CompareTag("DestructibleWall"))
            {
                Destroy(hit.collider.gameObject);
            }
        }

        durabilidad = 0;
        takeGuns.DesactivarArmas();
    }
}
