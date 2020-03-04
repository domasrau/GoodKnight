using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Sprite opened;
    public GameObject diamond;
    public GameObject diamondPrefab;
    public Transform transformObj;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player touched me.. (" + gameObject.name + ")");
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = opened;
                diamond = GameObject.Instantiate(diamondPrefab, this.transform.position, this.transform.rotation);
                diamond.transform.position = transformObj.position;
                //diamond.SetActive(true);
            }
            
        }
    }

    private void Start()
    {
        //diamond.SetActive(false);
    }

}
