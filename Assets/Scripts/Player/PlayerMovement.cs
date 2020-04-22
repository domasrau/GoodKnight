using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    private Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    [HideInInspector] public bool canMove;

    private float fallingSpeed;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {

            // Move our character
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }

        if (GetComponent<Rigidbody2D>().velocity.y <= -0.01f && !controller.IsGrounded())
        {
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }
        fallingSpeed = GetComponent<Rigidbody2D>().velocity.y;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        canMove = true;
        fallingSpeed = 0;
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
}