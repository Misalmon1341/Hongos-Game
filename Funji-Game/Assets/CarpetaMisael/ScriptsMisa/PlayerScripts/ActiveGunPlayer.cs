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
            bool wasTook = takeGuns.ActiveGuns(numeroArma);

            if(wasTook)
            {
                Destroy(gameObject);
            }
        }
    }
}
