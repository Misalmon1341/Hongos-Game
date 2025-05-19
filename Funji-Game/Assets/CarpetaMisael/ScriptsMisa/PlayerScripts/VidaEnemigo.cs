using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaEnemigo : MonoBehaviour, IDamageable
{
    public int vidaEnemigo = 10;
    public Slider BarraVidaEnemigo;

    public void TakeDamage(int amount)
    {
        vidaEnemigo -= amount;
        if (vidaEnemigo <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        BarraVidaEnemigo.value = vidaEnemigo;
    }
}
