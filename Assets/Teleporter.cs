using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public bool isActive = false;
    public GameObject cover;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player touched me.. (" + gameObject.name + ")");
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isActive)
                {
                    PlayerPrefs.SetInt("Coins", collision.gameObject.GetComponent<Player>().coins);
                    SceneManager.LoadSceneAsync(2);
                    Debug.LogError("Teleporting");
                }
                
            }

        }
    }

    public void DisableCover()
    {
        cover.SetActive(false);
        isActive = true;
    }
}
