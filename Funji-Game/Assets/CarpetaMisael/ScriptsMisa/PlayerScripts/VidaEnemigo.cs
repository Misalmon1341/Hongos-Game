using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaEnemigo : MonoBehaviour, IDamageable
{
    public int vidaEnemigo = 10;
    public Slider BarraVidaEnemigo;

    private void Update()
    {
        if (BarraVidaEnemigo != null)
            BarraVidaEnemigo.value = vidaEnemigo;
    }

    public void TakeDamage(int amount)
    {
        vidaEnemigo -= amount;
        if (vidaEnemigo <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        Destroy(gameObject);
    }
}
