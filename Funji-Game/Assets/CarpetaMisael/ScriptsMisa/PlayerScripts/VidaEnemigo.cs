using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class VidaEnemigo : MonoBehaviour, IDamageable
{
    public int vidaEnemigo = 10;
    public Slider BarraVidaEnemigo;
    public Animator animator;
    public GameObject target;
    public void TakeDamage(int amount)
    {
        vidaEnemigo -= amount;
        if (vidaEnemigo <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void FollowPlayer()
    {
       if (Vector3.Distance(transform.position, target.transform.position) < 2)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation,2);
            animator.SetBool("Correr", true);
            transform.Translate(Vector3.forward * 2* Time.deltaTime);
        }
    }

    private void Update()
    {
        BarraVidaEnemigo.value = vidaEnemigo;
    }
}
