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
    public GameObject panelEstres;       
    public float duracionPanel = 1f;    
    public int vidasTotales = 4;
    public GameObject gameOver;
    public GameObject panelGameplay;

    private int vidasActuales;
    private bool puedeRecibirDanio = true;
    private bool poderReiniciar = false;

    void Start()
    {
        vidasActuales = vidasTotales;
        ActualizarSpriteVida();
        panelEstres.SetActive(false);
        gameOver.SetActive(false);
        panelGameplay.SetActive(true);
    }
    private void Update()
    {
        if (poderReiniciar == true)
        {
        if (Input.GetKeyDown(KeyCode.R))
        {
           SceneManager.LoadScene(0);
        }
        }
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
            panelEstres.SetActive(false);
            panelGameplay.SetActive(false);
            poderReiniciar = true;
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
