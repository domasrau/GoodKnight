using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private ParticleSystem particle;
    private bool collected = false;
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
            if (!collected)
            {
                collected = true;
                GetComponent<AudioSource>().Play();
                if (particle != null)
                {
                    particle.Play();
                }
                Debug.Log("Player touched me.. (" + gameObject.name + ")");
                collision.gameObject.GetComponent<Player>().AddCoins(value);
                value = 0;
                GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DestroyAfterTime(0.5f));
            }
        }
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(this.gameObject);
    }
}
