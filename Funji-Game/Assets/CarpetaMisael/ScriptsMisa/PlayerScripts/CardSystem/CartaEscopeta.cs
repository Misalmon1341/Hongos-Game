using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaEscopeta : CartaBase
{

    [Header("Disparo")]
    public GameObject perdigonPrefab;
    public Transform spawnPoint;
    public float velocidadPerdigon = 10f;
    public int cantidadPerdigones = 5;
    public float anguloDispersion = 50f;

    [Header("Láser")]
    public LineRenderer laserRenderer;
    public float laserDuracion = 0.1f;
    public float alcance = 10f;
    public LayerMask layerDestructible;

    public override void Usar()
    {
        if (durabilidad <= 0) return;


        DisparoHelper.EjecutarAnimacionDisparo(movPersonaje.Animator);

        Vector3 direccionBase = movPersonaje.transform.forward; // ← o → según la rotación
        float inicioAngulo = -anguloDispersion / 2f;
        float incremento = anguloDispersion / (cantidadPerdigones - 1);

        for (int i = 0; i < cantidadPerdigones; i++)
        {
            float angulo = inicioAngulo + incremento * i;
            Quaternion rotacionDisparo = Quaternion.AngleAxis(angulo, Vector3.up); // rotación en eje Z

            Vector3 direccionDisparo = rotacionDisparo * direccionBase;

            GameObject perdigon = Instantiate(perdigonPrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody rb = perdigon.GetComponent<Rigidbody>();
            rb.velocity = direccionDisparo.normalized * velocidadPerdigon;
        }



        durabilidad--;
        if (durabilidad <= 0) Descartar();
    }

    public override void UsarHabilidad()
    {
        if (durabilidad <= 0) return;

        DisparoHelper.EjecutarAnimacionDisparo(movPersonaje.Animator);

        Vector3 origen = spawnPoint.position;
        Vector3 direccion = spawnPoint.right;

        if (Physics.Raycast(origen, direccion, out RaycastHit hit, alcance, layerDestructible))
        {
            Destroy(hit.collider.gameObject);
        }

        if (laserRenderer != null)
        {
            laserRenderer.SetPosition(0, origen);
            laserRenderer.SetPosition(1, origen + direccion * alcance);
            laserRenderer.enabled = true;
            Invoke(nameof(DesactivarLaser), laserDuracion);
        }

        durabilidad = 0;
        Descartar();
    }

    void DesactivarLaser()
    {
        if (laserRenderer != null)
        {
            laserRenderer.enabled = false;
        }
    }
}
