using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CartaBase : MonoBehaviour, ICarta
{
    [Header("Munición")]
    public int durabilidad;

    protected TakeGuns takeGuns;
    [HideInInspector] public Animator anim;
    protected Shot shot;
    protected MovPersonaje movPersonaje;


    protected virtual void Awake()
    {
        takeGuns = GameObject.FindGameObjectWithTag("Player").GetComponent<TakeGuns>();
        movPersonaje = GameObject.FindGameObjectWithTag("Player").GetComponent<MovPersonaje>();
        shot = GetComponent<Shot>();
    }

    public abstract void Usar();
    public abstract void UsarHabilidad();
    public void Descartar()
    {
        Debug.Log("Descartando carta: " + gameObject.name);
        gameObject.SetActive(false);

        takeGuns.DesactivarArmas();
    }
}
