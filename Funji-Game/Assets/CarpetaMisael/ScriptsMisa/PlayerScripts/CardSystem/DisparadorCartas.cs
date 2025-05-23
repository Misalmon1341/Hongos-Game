using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorCartas : MonoBehaviour
{
    public CartaBase cartaActiva;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && cartaActiva != null)
        {
            cartaActiva.Usar();
        }

        if (Input.GetButtonDown("Fire2") && cartaActiva != null)
        {
            cartaActiva.UsarHabilidad();
        }
    }
}
