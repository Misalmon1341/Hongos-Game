using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaUzi : CartaBase
{
    public GameObject bombaPrefab;

    protected override void EjecutarDisparo()
    {
        shot.Disparar(); 
    }

    public override void UsarHabilidad()
    {
        GameObject bomba = Instantiate(bombaPrefab, shot.spawnPoint.position, Quaternion.identity);
        bomba.GetComponent<Rigidbody>().velocity = transform.forward * 10f;
        durabilidad = 0;
        gameObject.SetActive(false);
    }
}
