using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VidaPlayer : MonoBehaviour
{
    public Sprite[] vidaSprites;        
    public Image imagenVida;             
    public float duracionPanel = 1f;    
    public int vidasTotales = 4;
    

    private int vidasActuales;
    private bool puedeRecibirDanio = true;
    public bool poderReiniciar = false;
    public PanelController panelController;

    void Start()
    {
        vidasActuales = vidasTotales;
        ActualizarSpriteVida();
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

        panelController.panelEstres.SetActive(true);

        if (vidasActuales <= 0)
        {
            Morir();
        }

        yield return new WaitForSeconds(duracionPanel);

        panelController.panelEstres.SetActive(false);
        puedeRecibirDanio = true;
    }

    void ActualizarSpriteVida()
    {
        int index = Mathf.Clamp(vidasTotales - vidasActuales, 0, vidaSprites.Length - 1);
        imagenVida.sprite = vidaSprites[index];
    }

    public void Morir()
    {
        Debug.Log("¡Jugador muerto!");

        GetComponent<Animator>().SetBool("Dead", true); // Si tienes animación

        poderReiniciar = true;

        panelController.gameOver.SetActive(true);
        panelController.panelEstres.SetActive(false);
        panelController.panelGameplay.SetActive(false);

        Time.timeScale = 0f; // Pausa el juego
    }
}
