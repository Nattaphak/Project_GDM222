using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject player;
    private bool isPaused = false; 

    void Start() 
    {
        
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // หยุดเวลาในเกม
        isPaused = true;
        gameOverUI.SetActive(true);; // เปิดเมนูหยุดเกม
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // เริ่มเวลาในเกมใหม่
        isPaused = false;
        gameOverUI.SetActive(false); // ปิดเมนูหยุดเกม
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene 1");
        Time.timeScale = 1;

        gameOverUI.SetActive(false);
        NextStage.instance.enemyCount = 5;
        NextStage.instance.stageCount = 1;
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        NextStage.instance.enemyCount = 5;
        NextStage.instance.stageCount = 1;
        SceneManager.LoadScene("MainMenu");
    }

}
