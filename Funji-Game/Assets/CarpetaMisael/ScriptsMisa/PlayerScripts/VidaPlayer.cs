using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaPlayer : MonoBehaviour
{
    private int vidaJugador = 4;

    public Sprite[] fases;
    public Image psique;
    public GameObject extreñimiento;
    void Start()
    {
        extreñimiento.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            vidaJugador--;
            StartCoroutine(ActivarExtreñimiento());

        }
    }
    
    IEnumerator ActivarExtreñimiento()
    {
        extreñimiento.SetActive(true);
        yield return new WaitForSeconds(1f);
        extreñimiento.SetActive(false);
    }
    void Update()
    {
        
    }
}
