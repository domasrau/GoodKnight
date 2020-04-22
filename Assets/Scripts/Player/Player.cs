using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float health = 100;
    public int coins = 0;
    public TextMeshProUGUI coinText;
    public LevelController levelController;
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        coins = 0;
        AddCoins(0);
        //this.gameObject.transform.position = levelController.checkPoint.position;
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DieIfFalling();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        coinText.text = "Coins: " + coins;
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


}
