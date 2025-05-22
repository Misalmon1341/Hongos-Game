using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaEscopeta : CartaBase
{
    public GameObject perdigonPrefab;
    public Transform spawnPoint;
    public float dispersion = 8f;
    public float fuerzaDisparo = 10f;
    private LineRenderer lineRenderer;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        shot = GetComponent<Shot>();
        takeGuns = GetComponent<TakeGuns>();
    }
    public override void Usar()
    {
        if (durabilidad <= 0) return;

        if (shot != null)
        {
            StartCoroutine(shot.DispararConDelay(0.3f));
            durabilidad--;
        }

        if (durabilidad <= 0)
        {
            takeGuns.DesactivarArmas();
        }
    }

    public override void UsarHabilidad()
    {
        if (spawnPoint == null || takeGuns == null || lineRenderer == null) return;

        RaycastHit hit;
        Vector3 endPoint = spawnPoint.position + spawnPoint.forward * 20f;

        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit, 20f))
        {
            endPoint = hit.point;

            if (hit.collider.CompareTag("DestructibleWall"))
            {
                Destroy(hit.collider.gameObject);
            }
        }

        StartCoroutine(MostrarLaser(spawnPoint.position, endPoint));

        if (shot != null)
        {
            StartCoroutine(shot.DispararConDelay(0.05f));
        }

        durabilidad = 0;
        takeGuns.DesactivarArmas();
    }
    private IEnumerator MostrarLaser(Vector3 inicio, Vector3 fin)
    {
        if (lineRenderer == null) yield break;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, inicio);
        lineRenderer.SetPosition(1, fin);
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.2f); // Tiempo visible

        lineRenderer.enabled = false;
    }
}
