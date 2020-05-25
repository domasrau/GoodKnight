using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelController : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Animator>().SetBool("hasSword", true);
        player.GetComponent<Player>().AddCoins(PlayerPrefs.GetInt("Coins", 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
