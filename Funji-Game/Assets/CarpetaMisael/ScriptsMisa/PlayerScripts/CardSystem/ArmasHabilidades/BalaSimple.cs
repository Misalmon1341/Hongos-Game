using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaSimple : MonoBehaviour
{
    public int damage = 30; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
