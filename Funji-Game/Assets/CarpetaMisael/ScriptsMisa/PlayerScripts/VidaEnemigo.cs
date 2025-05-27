using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class VidaEnemigo : MonoBehaviour, IDamageable
{
    public int vidaEnemigo = 10;
    public Slider BarraVidaEnemigo;
    private Animator animator;
    public GameObject target;

    public bool atacando;

    private void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");

    }
    public void TakeDamage(int amount)
    {
        vidaEnemigo -= amount;
        if (vidaEnemigo <= 0)
        {
            
            animator.SetBool("Morir", true);
            StartCoroutine(MuerteEnemigo());
        }
    }
    public void FollowPlayer()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando)

        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            animator.SetBool("Correr", true);
            transform.Translate(Vector3.right * 2 * Time.deltaTime);
            animator.SetBool("Atacar",false);
        }
        else
        {
            animator.SetBool("Correr",false);
            animator.SetBool("Pegar",true);

            animator.SetBool("Atacar", true);
            atacando = true;
        } 
        
    }
    public void Animacion_Final()
    {
        animator.SetBool("Atacar", false);
        atacando = false;
    }


    private void Update()
    {
        BarraVidaEnemigo.value = vidaEnemigo;
        //FollowPlayer();
    }
    IEnumerator MuerteEnemigo() 
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
