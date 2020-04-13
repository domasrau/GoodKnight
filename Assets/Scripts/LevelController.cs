using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public Transform checkPoint;
    public Player player;

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

    public void SaveCheckPoint(Transform transform)
    {
        checkPoint.position = transform.position;
        PlayerPrefs.SetFloat("PlayerPositionX", checkPoint.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", checkPoint.position.y);
    }
}
