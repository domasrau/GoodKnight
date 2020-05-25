using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWalk : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rigidbody;
    public float speed = 2.5f;
    public float attackRange = 3f;
    Enemy enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!enemy.isBoss && enemy.canMove == false)
        {
            Debug.LogWarning("NEJUDU ");
            return;
        }
        enemy.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rigidbody.position.y);
        Vector2 newPos = Vector2.MoveTowards(rigidbody.position, target, speed * Time.fixedDeltaTime);
        rigidbody.MovePosition(newPos);

        if (Vector2.Distance(player.position, rigidbody.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
            if (!animator.GetComponent<AudioSource>().isPlaying)
            {
                animator.GetComponent<AudioSource>().Play();
            }
            
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
