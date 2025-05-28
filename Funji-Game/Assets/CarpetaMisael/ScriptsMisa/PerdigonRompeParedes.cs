using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerdigonRompeParedes : MonoBehaviour
{
    public float tiempoDeVida = 3f;

    private void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            Destroy(collision.gameObject); 
        }

        Destroy(gameObject);
    }
}
