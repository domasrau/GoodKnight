using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public int currentHealth = 5;
    public int maxHealth = 5;
    public int coins = 0;
    public int score = 0;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    public LevelController levelController;
    private Rigidbody2D rigidbody;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Transform jumpingAttackPoint;
    public float jumpingAttackRange = 0.5f;

    public Transform swordAttackPoint;
    public float swordAttackRange = 0.5f;
    public int swordAttackDamage = 100;

    public float attackRate = 2f;
    float nextAttackTime = 0;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        coins = 0;
        score = 0;
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

    private void FixedUpdate()
    {
        if (GetComponent<CharacterController2D>().IsGrounded())
        {
            JumpAttack();
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
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
        GetComponent<ParticleSystem>().Play();
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


    public void JumpAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(jumpingAttackPoint.position, jumpingAttackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.LogError("I hit " + enemy.name);
            if (enemy.name == "Skeleton")
            {
                enemy.GetComponent<Enemy>().Die();
            }
            
        }
    }


    public void Attack()
    {
        if (!GetComponent<Animator>().GetBool("hasSword"))
        {
            return;
        }

        GetComponent<Animator>().SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordAttackPoint.position, swordAttackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.LogError("I hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(swordAttackDamage);
        }
    }


    public void OnDrawGizmosSelected()
    {
        if (swordAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(swordAttackPoint.position, swordAttackRange);
    }

}
