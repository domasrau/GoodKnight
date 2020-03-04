using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;

    public void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverPanel.activeSelf || levelCompletePanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                RestartLevel();
            }            
        }
    }


    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void LevelComplete()
    {
        Time.timeScale = 0;
        levelCompletePanel.SetActive(true);
    }
}
