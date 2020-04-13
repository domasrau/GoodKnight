using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public LevelController levelController;
    private bool isLit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player touched me.. (" + gameObject.name + ")");
            GetComponent<Animator>().SetBool("isLit", true);
            if (!isLit)
            {
                GetComponent<AudioSource>().Play();
            }
            isLit = true;
            levelController.SaveCheckPoint(collision.gameObject.transform);
        }
    }
}
