using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject deactiveSpawner;
    public GameObject onGame;
    public GameObject gameOverScreen;
    public TextMeshProUGUI surviveSecondsUI;
    public TextMeshProUGUI killCounter;
    bool gameOver;

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FindObjectOfType<EnemyController>().setKills(0);
                SceneManager.LoadScene(0);
            }
        }
    }
    public void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        surviveSecondsUI.text = "You Lived: " + ((int)Time.timeSinceLevelLoad).ToString() + " Secs";
        killCounter.text = "You Destroyed: " + FindObjectOfType<EnemyController>().getKills().ToString() + " Ships";
        deactiveSpawner.SetActive(false);
        onGame.SetActive(false);
        gameOver = true;
    }
}
