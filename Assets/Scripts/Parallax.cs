using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxSpeed;
    private float lastCameraX;

    // Update is called once per frame
    void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * parallaxSpeed);

        lastCameraX = cameraTransform.position.x;
    }
}