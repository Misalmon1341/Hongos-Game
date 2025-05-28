using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorCartas : MonoBehaviour
{
    public CartaBase cartaActiva;

    void Update()
    {
        if (cartaActiva == null)
        {
            Debug.Log("No hay carta activa asignada");
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            cartaActiva.Usar();
            Debug.Log("Está llamando al disparo");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            cartaActiva.UsarHabilidad();
            Debug.Log("Está llamando a la habilidad");
        }
    }
}
