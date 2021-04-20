using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private Animator animator;

    private Vector2 lastDirection; // keep track of where you last moved for idle animation


    // Start is called before the first frame update
    void Start()
    {
        lastDirection = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        lastDirection.x = 0; // initialize so facing down
        lastDirection.y = -1;
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    void handleMovement()
    {
        Vector2 moveDirection = Vector2.zero; // initialize vector
        if (Input.GetKey(KeyCode.A)) // build vector components with WASD
        {
            moveDirection.x = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = 1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y = -1f;
        }

        if (Input.GetKey(KeyCode.LeftControl)) // holding ctrl to walk slowly
        {
            speed = 2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl)) // when you let go of control, return to normal speed
        {
            speed = 3.5f;
        }

        if (moveDirection != Vector2.zero) //only change last direction if moved
        {
            lastDirection = moveDirection; // NOT NORMALIZED
            animator.SetBool("Moving", true); // moving
        } 
        else
        {
            animator.SetBool("Moving", false); // not moving
        }

        animator.SetFloat("Horizontal", lastDirection.x); // update animation vertical and horizontal floats
        animator.SetFloat("Vertical", lastDirection.y);
        moveDirection.Normalize(); // length = 1
        rb.velocity = speed * moveDirection;
    }

}
