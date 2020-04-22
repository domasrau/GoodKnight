using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    private bool isPulled = false;
    public GameObject stick;
    public GameObject pivot;

    // Update is called once per frame
    void Update()
    {
        if (isPulled && stick.transform.rotation.z >= 0)
        {
            stick.transform.RotateAround(pivot.transform.position, Vector3.back, 30 * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isPulled)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isPulled = true;
                    GetComponent<ParticleSystem>().Play();
                    GetComponent<AudioSource>().Play();
                }
            }
        }
    }
}
