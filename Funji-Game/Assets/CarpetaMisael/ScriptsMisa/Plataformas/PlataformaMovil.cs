using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    private float velocidadPlataforma = 2f;
    void FixedUpdate()
    {
        this.transform.position += new Vector3(velocidadPlataforma * Time.deltaTime, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
        else
        {
            velocidadPlataforma *= -1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(this.transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
