using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float health = 100;
    public int coins = 0;
    public TextMeshProUGUI coinText;


    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        coins = 0;
        AddCoins(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        coinText.text = "Coins: " + coins;
    }
}
