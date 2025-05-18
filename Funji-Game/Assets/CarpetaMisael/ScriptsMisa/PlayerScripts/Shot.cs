using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [Header("Referencias")]
    public Transform spawnPoint;               
    public GameObject balaPrefab;
    public MovPersonaje movPersonaje;          
    [Header("Parámetros de disparo")]
    public float velocidadBala = 10f;
    public float delayDisparo = 0.2f;

    private bool puedeDisparar = true;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && puedeDisparar)
        {
            CartaBase carta = GetComponent<CartaBase>();
            if (carta != null) carta.Usar();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            CartaBase carta = GetComponent<CartaBase>();
            if (carta != null) carta.UsarHabilidad();
        }
    }

    public IEnumerator DispararConDelay(float delay)
    {
        puedeDisparar = false;

        
      

        yield return new WaitForSeconds(delay);
      
        if (movPersonaje != null)
        {
            movPersonaje.Animator.SetTrigger("Shoot");
        }
        Disparar();

      
        yield return new WaitForSeconds(0.3f);
        puedeDisparar = true;
    }

    public void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, spawnPoint.position, Quaternion.identity);
        Vector3 direccionDisparo = transform.forward;
        bala.GetComponent<Rigidbody>().velocity = direccionDisparo * velocidadBala;
    }
}

