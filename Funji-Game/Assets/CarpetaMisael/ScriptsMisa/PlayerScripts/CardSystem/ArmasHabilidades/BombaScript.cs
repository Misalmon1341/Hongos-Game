using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaScript : MonoBehaviour
{
    public float radioExplosion = 5f;
    public int daño = 999; // Daño letal
    public GameObject efectoExplosion;
    public LayerMask capaEnemigos;

    private void OnCollisionEnter(Collision collision)
    {
        Explotar();
    }

    void Explotar()
    {
        // Efecto visual
        if (efectoExplosion != null)
        {
            GameObject efecto = Instantiate(efectoExplosion, transform.position, Quaternion.identity);
            efecto.GetComponent<ParticleSystem>().Play();
            Destroy(efecto, 2f);
        }

        // Buscar todos los colliders dentro del área de la explosión
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioExplosion, capaEnemigos);

        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(daño);
            }
        }

        // Destruir la bomba tras explotar
        Destroy(gameObject);
    }
}
