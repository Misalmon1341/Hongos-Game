using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class VidaEnemigo : MonoBehaviour, IDamageable
{
    public int vidaEnemigo = 10;
    public Slider barraVidaEnemigo;
    private Animator animator;

    private bool muerto = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

  
    public void TakeDamage(int amount)
    {
        if (muerto) return;

        vidaEnemigo -= amount;

        if (vidaEnemigo <= 0)
        {
            StartCoroutine(MuerteEnemigo());
        }
    }

    IEnumerator MuerteEnemigo()
    {
        muerto = true;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
