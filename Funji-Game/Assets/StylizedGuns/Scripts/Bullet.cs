using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explotion;
    private GameObject lastExplotion;

    void OnCollisionEnter(Collision collision)
    {
        // Evita colisión con otras balas
        if (collision.gameObject.CompareTag("Bullet"))
            return;

        // Instancia la explosión en la posición de impacto
        if (explotion != null)
        {
            lastExplotion = Instantiate(explotion, transform.position, Quaternion.identity);
            Destroy(lastExplotion, 1f);
        }

        // Destruye la bala
        Destroy(gameObject);
    }

}
