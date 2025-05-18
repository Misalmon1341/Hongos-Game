using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaScript : MonoBehaviour
{
    public float radioExplosion = 2.5f; 
    public LayerMask Enemigo;
    public GameObject efectoExplosion;

    private void OnCollisionEnter(Collision collision)
    {
        Explota();
    }

    void Explota()
    {
        
        if (efectoExplosion)
            Instantiate(efectoExplosion, transform.position, Quaternion.identity);

        
        Collider[] enemigos = Physics.OverlapSphere(transform.position, radioExplosion, Enemigo);
        foreach (Collider enemigo in enemigos)
        {
            Destroy(enemigo.gameObject);
        }

        Destroy(gameObject); 
    }
}
