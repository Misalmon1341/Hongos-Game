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
    public float anguloDispersión = 50f;

    [Header("Láser")]
    public LineRenderer laserRenderer;
    public float laserDuracion = 0.1f;
    public float alcance = 10f;
    public LayerMask layerDestructible;

    public override void Usar()
    {
        if (durabilidad <= 0) return;

        DisparoHelper.EjecutarAnimacionDisparo(anim);

        float inicioAngulo = -anguloDispersión / 2f;
        float incremento = anguloDispersión / (cantidadPerdigones - 1);

        for (int i = 0; i < cantidadPerdigones; i++)
        {
            float angulo = inicioAngulo + (incremento * i);
            Quaternion rotacion = Quaternion.Euler(0, angulo, 0);
            Vector3 direccion = rotacion * spawnPoint.right;

            GameObject perdigon = Instantiate(perdigonPrefab, spawnPoint.position, Quaternion.identity);
            perdigon.GetComponent<Rigidbody>().velocity = direccion * velocidadPerdigon;
        }

        durabilidad--;
        if (durabilidad <= 0)
            takeGuns.DesactivarArmas();
    }

    public override void UsarHabilidad()
    {
        if (durabilidad <= 0) return;

        DisparoHelper.EjecutarAnimacionDisparo(anim);

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
        takeGuns.DesactivarArmas();
    }

    void DesactivarLaser()
    {
        if (laserRenderer != null)
        {
            laserRenderer.enabled = false;
        }
    }
}
