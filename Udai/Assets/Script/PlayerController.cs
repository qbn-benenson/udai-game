using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    void handleMovement()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1f;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = 2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = 5f;
        }
        direction.Normalize();
        rb.velocity = speed * direction;
    }
}
