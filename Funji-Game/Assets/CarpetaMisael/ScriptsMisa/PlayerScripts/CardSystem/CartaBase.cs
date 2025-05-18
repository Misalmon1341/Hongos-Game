using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CartaBase : MonoBehaviour
{
    public int durabilidad;
    public float cooldownDisparo;
    protected bool puedeDisparar = true;
    protected Shot shot;

    protected virtual void Start()
    {
        shot = GetComponent<Shot>();
    }

    public virtual void Usar()
    {
        if (puedeDisparar && durabilidad > 0)
        {
            StartCoroutine(Disparar());
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

    protected abstract void EjecutarDisparo();
    public abstract void UsarHabilidad(); 
}
