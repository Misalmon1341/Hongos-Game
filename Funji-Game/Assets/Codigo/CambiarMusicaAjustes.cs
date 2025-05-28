using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarMusicaAjustes : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Ajustes")
            Audio.instance.GetComponent<AudioSource>().Play();

        if (SceneManager.GetActiveScene().name == "Controles")
            Audio.instance.GetComponent<AudioSource>().Play();
        if (SceneManager.GetActiveScene().name == "MenuPrincipal")
            Audio.instance.GetComponent<AudioSource>().Pause();
        if (SceneManager.GetActiveScene().name == "Creditos")
            Audio.instance.GetComponent<AudioSource>().Pause();
    }
}
