using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float currentHealth = 5;
    public float maxHealth = 5;
    public int coins = 0;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    public LevelController levelController;
    private Rigidbody2D rigidbody;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        coins = 0;
        AddCoins(0);
        //this.gameObject.transform.position = levelController.checkPoint.position;
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        healthText.text = "Health Points: " + currentHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        DieIfFalling();
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            AddHealth(1);
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < 5)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        coinText.text = coins.ToString();
    }

    public void DieIfFalling()
    {
        if (rigidbody.velocity.y <= -100)
        {
            levelController.GameOver();
        }
    }


    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        while (knockDur > timer)
        {

            timer += Time.deltaTime;

            rigidbody.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));

        }
        yield return 0;
    }

    public void Die()
    {
        levelController.GameOver();
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthText.text = "Health Points: " + currentHealth.ToString();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            healthText.text = "Health Points: " + currentHealth.ToString();
            Die();
        }
    }

    public void AddHealth(int amount)
    {
        if (currentHealth + amount >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = currentHealth + amount;
        }
        healthText.text = "Health Points: " + currentHealth.ToString();
    }


}
