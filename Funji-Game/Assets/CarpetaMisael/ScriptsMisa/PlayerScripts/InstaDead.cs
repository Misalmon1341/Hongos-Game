using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaDead : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VidaPlayer vida = other.GetComponent<VidaPlayer>();
            if (vida != null)
            {
                vida.Morir();
            }
        }
    }

}
