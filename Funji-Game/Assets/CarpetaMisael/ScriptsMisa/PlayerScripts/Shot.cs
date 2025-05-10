using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    public GameObject[] bulletPrefabs;
    public Transform spawnPoint;
    private int numeroGun;

    public CardUIManager cardUI;


    public float shotForce = 1500;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shotRateTime)
            {
                if (cardUI != null && cardUI.CardCount() > 0)
                {
                    int tipoDeCarta = cardUI.UseCard(0); 

                    if (tipoDeCarta >= 0 && tipoDeCarta < bulletPrefabs.Length)
                    {
                        GameObject newBullet = Instantiate(bulletPrefabs[tipoDeCarta], spawnPoint.position, spawnPoint.rotation);
                        newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
                        Destroy(newBullet, 2f);

                        shotRateTime = Time.time + shotRate;
                    }
                }
            }
        }
    }
}
