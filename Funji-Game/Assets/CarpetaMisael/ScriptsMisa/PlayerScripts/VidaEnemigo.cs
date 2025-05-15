using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaEnemigo : MonoBehaviour
{
    public int vidaEnemigo;
    public Slider BarraVidaEnemigo;
    public int damage;
    private void Update()
    {
        BarraVidaEnemigo.value = vidaEnemigo;
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("bala"))
       {
            vidaEnemigo -=damage;
            Destroy(other.gameObject);
            if (vidaEnemigo < 0)
            {
               Destroy(gameObject);
            }
       }
        
    }
}
