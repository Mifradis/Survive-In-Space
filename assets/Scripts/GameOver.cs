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
    
    KillCounter counter;
    bool gameOver;

    void Start()
    {
        
    }
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        surviveSecondsUI.text = "You Lived: " + ((int)Time.timeSinceLevelLoad).ToString() + " Secs";
        deactiveSpawner.SetActive(false);
        onGame.SetActive(false);
        gameOver = true;
        
    }
}
