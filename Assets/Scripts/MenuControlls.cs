using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlls : MonoBehaviour
{
    public GameObject aboutPage;
    public GameObject levelSelect;
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
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SampleScene");
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

    public void LoadLevel1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
