using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [Header("Referencias")]
    public Transform spawnPoint;               // Hijo del arma (bien alineado al cañón)
    public GameObject balaPrefab;
    public MovPersonaje movPersonaje;          // Referencia al script que ya tiene el Animator

    [Header("Parámetros de disparo")]
    public float velocidadBala = 10f;
    public float delayDisparo = 0.2f;

    private bool puedeDisparar = true;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && puedeDisparar)
        {
            StartCoroutine(DispararConDelay(delayDisparo));
        }
    }

    IEnumerator DispararConDelay(float delay)
    {
        puedeDisparar = false;

        // Activar la animación desde el Animator que tiene MovPersonaje
        if (movPersonaje != null)
        {
            movPersonaje.Animator.SetTrigger("Disparar");
        }

        yield return new WaitForSeconds(delay);

        Disparar();

        // Cooldown entre disparos
        yield return new WaitForSeconds(0.3f);
        puedeDisparar = true;
    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, spawnPoint.position, Quaternion.identity);

        // Dirección solo en X (izquierda o derecha según escala)
        Vector3 direccionDisparo = transform.localScale.x > 0 ? Vector3.right : Vector3.left;
        bala.GetComponent<Rigidbody>().velocity = direccionDisparo * velocidadBala;
    }
}

