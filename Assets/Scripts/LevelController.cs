using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public Transform checkPoint;
    public Text scoreText;
    public Player player;
    public int reloadScene = 1;

    public void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        player.gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPositionX", 2.3f), PlayerPrefs.GetFloat("PlayerPositionY", -23.9f), 0);
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
        scoreText.text = "SCORE: " + CalculateScore().ToString();
        gameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(reloadScene);
    }

    public void LevelComplete()
    {
        Time.timeScale = 0;
        levelCompletePanel.SetActive(true);
    }

    public void SaveCheckPoint(Transform transform)
    {
        checkPoint.position = transform.position;
        PlayerPrefs.SetFloat("PlayerPositionX", checkPoint.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", checkPoint.position.y);
    }

    public int CalculateScore()
    {
        int score = 0;
        score = player.score;
        score += player.coins * 100;
        score += player.currentHealth * 100;
        return score;
    }
}
