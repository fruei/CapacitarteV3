using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController main;

    public float tiempoLimite;
    private float _time;

    public int enemyStartCount;
    public int enemyKilledCount;

    public TextMeshProUGUI tiempoLimiteUGUI;
    public TextMeshProUGUI enemysCountUGUI;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {

        enemysCountUGUI.text = "Enemigos: " + enemyKilledCount + " / " + enemyStartCount;
        
        if (enemyKilledCount >= enemyStartCount)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        _time += Time.deltaTime;

        tiempoLimiteUGUI.text = "Tiempo restante: " + _time.ToString("f0");

        if (_time >= tiempoLimite)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}
