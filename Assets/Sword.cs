using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collected)
            {
                collected = true;
                Debug.Log("Player touched me.. (" + gameObject.name + ")");
                collision.gameObject.GetComponent<Animator>().SetBool("hasSword", true);
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
