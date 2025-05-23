using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoHelper : MonoBehaviour
{
    public static void EjecutarAnimacionDisparo(Animator anim)
    {
        if (anim != null)
        {
            anim.SetTrigger("Shoot");
        }
    }

    public static void DispararBala(GameObject prefab, Transform spawnPoint, float velocidad)
    {
        GameObject bala = Object.Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        float direccionX = Mathf.Sign(spawnPoint.transform.right.x);
        bala.GetComponent<Rigidbody>().velocity = new Vector3(direccionX, 0f, 0f) * velocidad;
    }
}
