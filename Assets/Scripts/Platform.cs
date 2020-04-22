using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isVertical; // if false -> is horizontal
    private bool goDown = true; // if false -> goes up
    public float positionCeiling;
    public float positionFloor;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        goDown = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("go down "+ goDown);
        //Debug.Log("pos " + this.transform.position.y);
        if (isVertical)
        {
            if (goDown)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed, 0);
                if (this.transform.position.y < positionCeiling)
                {
                    goDown = false;
                }
            }
            else
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed, 0);
                if (this.transform.position.y > positionFloor)
                {
                    goDown = true;
                }
            }
        }
        
    }
}
