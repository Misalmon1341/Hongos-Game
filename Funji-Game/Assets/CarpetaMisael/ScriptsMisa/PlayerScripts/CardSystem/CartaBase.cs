using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CartaBase : MonoBehaviour
{
    public int durabilidad;
    public float cooldownDisparo;
    protected bool puedeDisparar = true;
    protected Shot shot;
    [SerializeField] protected TakeGuns takeGuns;
    public int Durabilidad => durabilidad;
    protected virtual void Start()
    {
        shot = GetComponent<Shot>();
    }

    public virtual void Usar()
    {
        if (durabilidad <= 0) return;

        // Resto del disparo...
        StartCoroutine(shot.DispararConDelay(0.3f));
        durabilidad--;

        if (durabilidad <= 0)
        {
            takeGuns.DesactivarArmas();
        }
    }

    protected virtual IEnumerator Disparar()
    {
        puedeDisparar = false;
        EjecutarDisparo();
        durabilidad--;

        if (durabilidad <= 0)
        {
            gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(cooldownDisparo);
        puedeDisparar = true;
    }

    public virtual void EjecutarDisparo(){ }
    public virtual void UsarHabilidad(){ }
}
