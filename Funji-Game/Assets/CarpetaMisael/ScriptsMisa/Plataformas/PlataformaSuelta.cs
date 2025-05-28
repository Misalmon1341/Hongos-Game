using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSuelta : MonoBehaviour
{
    private float esperParaCaer = 1f;
    private float esperParaDestruir = 2f;
    private float esperaParaReaparecer = 2f;
    private Rigidbody rb;
    private Animator animacion;
    private Vector3 antiguaPosicion;

    void Start()
    {
        animacion = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        antiguaPosicion = this.gameObject.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Caida());
        }
    }  
    private IEnumerator Caida()
    {
        yield return new WaitForSeconds(esperParaCaer);
        rb.useGravity = enabled;
        yield return new WaitForSeconds(esperParaDestruir);
        this.gameObject.SetActive(false);
        Invoke("Reaparecer",esperaParaReaparecer);
    }
    private void Reaparecer()
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = antiguaPosicion;
        rb.useGravity = false;
        rb.velocity = new Vector3(0f, 0f, 0f);
        animacion.SetBool("Reaparece", true);
    }


}
