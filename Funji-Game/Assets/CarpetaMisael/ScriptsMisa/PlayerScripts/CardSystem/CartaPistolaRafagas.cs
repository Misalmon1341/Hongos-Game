using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaPistolaRafagas : CartaBase
{

    public GameObject balaPrefab;
    public Transform spawnPoint;

    public override void EjecutarDisparo()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject bala = Instantiate(balaPrefab, spawnPoint.position, Quaternion.identity);
            bala.GetComponent<Rigidbody>().velocity = transform.forward * 12f;
        }
    }

    public override void UsarHabilidad()
    {
        MovPersonaje mov = GetComponentInParent<MovPersonaje>();
        if (!mov.GetComponent<CharacterController>().isGrounded)
        {
            mov.Salto(); // Reusa tu método de salto
            durabilidad = 0;
            gameObject.SetActive(false);
        }
    }
}
