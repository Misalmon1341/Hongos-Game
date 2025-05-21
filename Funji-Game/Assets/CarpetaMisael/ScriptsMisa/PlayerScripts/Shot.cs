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

        Debug.Log("Esta ebtrando");
      
        if (movPersonaje != null)
        {
            movPersonaje.animacion.SetTrigger("Shoot");
            Debug.Log("Trigger llamado desde shot");
        }

        yield return new WaitForSeconds(delay);
      
        Disparar();

      
        yield return new WaitForSeconds(0.3f);
        puedeDisparar = true;
    }

    public void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, spawnPoint.position, Quaternion.identity);
        float direccionX = Mathf.Sign(transform.forward.x);
        Vector3 direccionDisparo = new Vector3(direccionX, 0f, 0f);
        bala.GetComponent<Rigidbody>().velocity = direccionDisparo * velocidadBala;
    }
}

