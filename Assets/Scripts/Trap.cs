using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player touched me.. (" + gameObject.name + ")");
            //collision.gameObject.GetComponent<Player>().levelController.GameOver();
            //StartCoroutine(collision.gameObject.GetComponent<Player>().Knockback(0.02f, 1, collision.gameObject.transform.position));
            Vector2 hitDirection = collision.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            //collision.gameObject.GetComponent<PlayerMovement>().canMove = false;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            collision.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(hitDirection * 700);
        }
    }

}
