using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public bool isDead = false;
    public bool opensAChest = false;
    public Chest chest;

    public int maxHealth = 100;
    int currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
        StartCoroutine(DisableCollider());

        if (opensAChest)
        {
            chest.OpenChest();
        }
    }

    public IEnumerator DisableCollider()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
