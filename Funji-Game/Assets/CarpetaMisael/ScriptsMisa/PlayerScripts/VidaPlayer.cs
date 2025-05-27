using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaPlayer : MonoBehaviour
{
    public Sprite[] vidaSprites;        
    public Image imagenVida;             
    public GameObject panelEstres;       
    public float duracionPanel = 1f;    
    public int vidasTotales = 4;
    public GameObject gameOver;

    private int vidasActuales;
    private bool puedeRecibirDanio = true;

    void Start()
    {
        vidasActuales = vidasTotales;
        ActualizarSpriteVida();
        panelEstres.SetActive(false);
        gameOver.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && puedeRecibirDanio)
        {
            StartCoroutine(RecibirDanio());
        }
    }

    IEnumerator RecibirDanio()
    {
        puedeRecibirDanio = false;

        vidasActuales--;
        ActualizarSpriteVida();

        panelEstres.SetActive(true);

        if (vidasActuales <= 0)
        {
            Morir();
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }

        yield return new WaitForSeconds(duracionPanel);

        panelEstres.SetActive(false);
        puedeRecibirDanio = true;
    }

    void ActualizarSpriteVida()
    {
        int index = Mathf.Clamp(vidasTotales - vidasActuales, 0, vidaSprites.Length - 1);
        imagenVida.sprite = vidaSprites[index];
    }

    void Morir()
    {
        Debug.Log("¡Jugador muerto!");
        Destroy(gameObject);
    }
}
