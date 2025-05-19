using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegacion : MonoBehaviour
{
    public void Jugar()
    {
        //Aquí va la escena del juego
    }
    public void Ajustes()
    {
        SceneManager.LoadScene("Ajustes");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void RegresarMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Sonido()
    {
        SceneManager.LoadScene("Sonido");
    }
}
