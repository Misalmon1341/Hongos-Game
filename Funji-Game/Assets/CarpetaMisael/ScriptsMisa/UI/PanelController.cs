using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public GameObject panelEstres;
    public GameObject gameOver;
    public GameObject panelGameplay;
    public VidaPlayer player;

    void Start()
    {
        panelEstres.SetActive(false);
        gameOver.SetActive(false);
        panelGameplay.SetActive(true);
    }

    void Update()
    {
        if (player != null && player.poderReiniciar)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
