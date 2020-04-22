using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Sprite opened;
    private GameObject diamond;
    public GameObject diamondPrefab;
    public Transform transformObj;
    private bool isOpened = false;
    
    private void Start()
    {
        //diamond.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isOpened)
            {
                Debug.Log("Player touched me.. (" + gameObject.name + ")");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isOpened = true;
                    Debug.LogError("Spawning");
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = opened;
                    diamond = GameObject.Instantiate(diamondPrefab, this.transform.position, this.transform.rotation);
                    diamond.transform.position = transformObj.position;
                    //diamond.SetActive(true);
                }
            }

        }
    }

}
