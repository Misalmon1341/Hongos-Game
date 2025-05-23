using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CartaBase : MonoBehaviour, ICarta
{
    [Header("Munición")]
    public int durabilidad;

    [HideInInspector] public TakeGuns takeGuns;
    [HideInInspector] public Animator anim;

    protected virtual void Awake()
    {
        takeGuns = GetComponent<TakeGuns>();
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    public abstract void Usar();
    public abstract void UsarHabilidad();
}
