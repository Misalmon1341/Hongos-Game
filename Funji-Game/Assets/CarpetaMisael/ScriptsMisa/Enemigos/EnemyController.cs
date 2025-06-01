using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform target;        
    public float speed = 2f;        
    public float stopDistance = 0.2f; 

    public bool enemyMove = false;

    void Update()
    {
        if (enemyMove && target != null)
        {
            float distanceX = target.position.x - transform.position.x;

            // Se mueve solo si no está suficientemente cerca
            if (Mathf.Abs(distanceX) > stopDistance)
            {
                float direction = Mathf.Sign(distanceX); // -1 o 1
                transform.position += new Vector3(direction * speed * Time.deltaTime, 0f, 0f);

                // Voltea visualmente al enemigo (solo si usas sprite o modelo mirando en X positivo)
                transform.localScale = new Vector3(direction > 0 ? 1 : -1, 1, 1);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyMove = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyMove = false;
        }
    }
}
