using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaEscopeta : CartaBase
{
    public GameObject perdigonPrefab;
    public Transform spawnPoint;
    public float spread = 5f;

    protected override void EjecutarDisparo()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 direccion = transform.forward + new Vector3(Random.Range(-spread, spread), 0, 0);
            GameObject bala = Instantiate(perdigonPrefab, spawnPoint.position, Quaternion.identity);
            bala.GetComponent<Rigidbody>().velocity = direccion.normalized * 10f;
        }
    }

    public override void UsarHabilidad()
    {
        RaycastHit hit;
        if (Physics.Raycast(spawnPoint.position, transform.forward, out hit, 10f))
        {
            if (hit.collider.CompareTag("DestructibleWall"))
            {
                Destroy(hit.collider.gameObject);
                durabilidad = 0;
                gameObject.SetActive(false);
            }
        }
    }
}
