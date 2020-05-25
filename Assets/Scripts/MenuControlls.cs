using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControlls : MonoBehaviour
{
    public GameObject aboutPage;
    public GameObject levelSelect;
    public GameObject settings;

    public Text musicText;
    public Text colorText;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void NewGame()
    {
        PlayerPrefs.SetInt("NewGame", 1);
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnableAboutPage()
    {
        aboutPage.SetActive(true);
    }

    public void CloseAboutPage()
    {
        aboutPage.SetActive(false);
    }

    public void EnableLevelSelect()
    {
        levelSelect.SetActive(true);
    }

    public void CloseLevelSelect()
    {
        levelSelect.SetActive(false);
    }

    public void EnableSettings()
    {
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadSceneAsync("BossLevel");
    }

    public void ToggleMusic()
    {
        int musicToggle = 1;
        if (musicText.text == "ON")
        {
            musicToggle = 0;
            musicText.text = "OFF";
            audio.Stop();
        }
        else
        {
            musicToggle = 1;
            musicText.text = "ON";
            audio.Play();
        }
        PlayerPrefs.SetInt("MusicToggle", musicToggle);
        Debug.Log("Music set to " + musicToggle.ToString());
    }

    public void ToggleColor()
    {
        int colorToggle = 1;
        if (colorText.text == "ON")
        {
            colorToggle = 0;
            colorText.text = "OFF";
        }
        else
        {
            colorToggle = 1;
            colorText.text = "ON";
        }
        PlayerPrefs.SetInt("ColorToggle", colorToggle);
        Debug.Log("Color set to " + colorToggle.ToString());
    }
}
