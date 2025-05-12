using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform spawnPoint;
    private int numeroGun;

    public float shotForce = 1500;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;
    public MovPersonaje movPersonaje;
    private void Start()
    {
        if (movPersonaje == null)
            movPersonaje = GetComponent<MovPersonaje>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shotRateTime)
            {
                Disparar();
                shotRateTime = Time.time + shotRate;
            }
        }
    }

    void Disparar()
    {
        GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
        Destroy(newBullet, 2f);

        if (movPersonaje != null)
        {
            movPersonaje.Animator.SetTrigger("Shoot");
        }
    }
}
