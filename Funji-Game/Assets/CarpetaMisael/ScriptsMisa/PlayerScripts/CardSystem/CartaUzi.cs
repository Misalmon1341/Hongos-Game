using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaUzi : MonoBehaviour
{
    public GameObject bombaPrefab;
    public Transform spawnPointBomba;
    public float fuerzaLanzamiento = 15f;
    public TakeGuns takeGuns;
    public int indexCarta; // el número de esta carta para TakeGuns

    private void Update()
    {
        if (Input.GetButtonDown("Fire2")) // Clic derecho
        {
            UsarHabilidad();
        }
    }

    void UsarHabilidad()
    {
        GameObject bomba = Instantiate(bombaPrefab, spawnPointBomba.position, Quaternion.identity);
        Rigidbody rb = bomba.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * fuerzaLanzamiento, ForceMode.VelocityChange);

        takeGuns.DesactivarArmas();
    }
}
