using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Sprite opened;
    public GameObject diamond;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player touched me.. (" + gameObject.name + ")");
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = opened;
                diamond.SetActive(true);
            }
            
        }
    }

    private void Start()
    {
        diamond.SetActive(false);
    }

}
