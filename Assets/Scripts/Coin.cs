using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;
    
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Player touched me.. (" + gameObject.name + ")");
    //        collision.gameObject.GetComponent<Player>().AddCoins(value);
    //        value = 0;
    //        Destroy(this.gameObject);
    //    }        
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            Debug.Log("Player touched me.. (" + gameObject.name + ")");
            collision.gameObject.GetComponent<Player>().AddCoins(value);
            value = 0;
            Destroy(this.gameObject);
        }
    }
}
