using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private bool goDown = true; // if false -> goes up

    // Start is called before the first frame update
    void Start()
    {
        goDown = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("go down "+ goDown);
        Debug.Log("pos " + this.transform.position.y);
        if (goDown)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.02f, 0);
            if (this.transform.position.y < -31)
            {
                goDown = false;
            }
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, 0);
            if (this.transform.position.y > -20)
            {
                goDown = true;
            }
        }
        
    }
}
