using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeGuns : MonoBehaviour
{
    public GameObject[] guns;
    public DisparadorCartas disparadorCartas; // <-- Añadido

    public void ActiveGuns(int numero)
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }

        guns[numero].SetActive(true);

        // Obtener la carta base del arma activada y asignarla al DisparadorCartas
        CartaBase carta = guns[numero].GetComponent<CartaBase>();
        if (carta != null && disparadorCartas != null)
        {
            carta.ResetearDurabilidad();
            disparadorCartas.cartaActiva = carta;
            Debug.Log("Carta activa asignada: " + carta.name);
        }
        else
        {
            Debug.LogWarning("No se pudo asignar la carta activa.");
        }
    }

    public void DesactivarArmas()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }
    }
}
