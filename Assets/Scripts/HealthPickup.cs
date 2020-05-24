using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private ParticleSystem particle;
    private bool collected = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collected)
            {
                collected = true;
                if (particle != null)
                {
                    particle.Play();
                }
                GetComponent<AudioSource>().Play();
                Debug.Log("Player touched me.. (" + gameObject.name + ")");
                collision.gameObject.GetComponent<Player>().AddHealth(value);
                value = 0;
                GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DestroyAfterTime(GetComponent<AudioSource>().clip.length));
            }
        }
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(this.gameObject);
    }
}
