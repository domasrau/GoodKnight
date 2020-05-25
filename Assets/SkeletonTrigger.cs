using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonTrigger : MonoBehaviour
{
    public Enemy skeleton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.LogError("Let skeleton walk ");
            skeleton.canMove = true;
        }
    }
}
