using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isBoss = false;
    public HealthBar healthBar;

    public Transform player;
    public bool isFlipped = false;
    public bool isDead = false;
    public bool opensAChest = false;
    public Chest chest;
    public AudioClip deathSound;
    public int scoreReward = 500;

    public int maxHealth = 100;
    int currentHealth;

    public Teleporter tp;


    private void Start()
    {
        currentHealth = maxHealth;
        if (isBoss)
        {
            healthBar.SetMaxValue(maxHealth);
        }
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
        GetComponent<Animator>().SetTrigger("Hit");
        if (isBoss)
        {
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        if (isBoss)
        {
            GetComponent<Animator>().SetBool("Die", true);
        }
        else
        {
            GetComponent<Animator>().SetTrigger("SkeleDie");
            tp.DisableCover();
        }
        
        GetComponent<AudioSource>().clip = deathSound;
        GetComponent<AudioSource>().Play();

        player.GetComponent<Player>().score += scoreReward;
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
