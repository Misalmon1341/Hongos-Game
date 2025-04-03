using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerMisa : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField, Tooltip("Tiempo en segundos")] private float timerTime;
    public GameObject panelGO;

    private int minutes, seconds, cents;

    private void Start()
    {
        panelGO.SetActive(false);
    }
    private void Update()
    {
        timerTime -= Time.deltaTime;

        if (timerTime < 0 ) timerTime = 0;
        minutes = (int)(timerTime/ 60f);
        seconds = (int)(timerTime - minutes * 60f);
        cents = (int)((timerTime - (int)timerTime) * 100f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);

        if (timerTime == 0)
        {
            panelGO.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
