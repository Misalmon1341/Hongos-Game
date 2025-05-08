using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGunPlayer : MonoBehaviour
{
    public TakeGuns takeGuns;
    public int numeroArma;
    

    private void Start()
    {
        takeGuns = GameObject.FindGameObjectWithTag("Player").GetComponent<TakeGuns>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            takeGuns.ActiveGuns(numeroArma);
            Destroy(gameObject);
        }
    }
}
