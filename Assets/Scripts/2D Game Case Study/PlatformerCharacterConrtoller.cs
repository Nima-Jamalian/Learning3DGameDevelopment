using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerCharacterConrtoller : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float jumpPower = 5f;
    [SerializeField] bool isGrounded = false;
    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            Jump();
        }

    }

    void Movement() {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {//going right
            spriteRenderer.flipX = false;
            if(isGrounded) {
                animator.SetBool("Walking", true);
            }

        }
        else if (horizontalInput < 0)
        {//going left
            spriteRenderer.flipX = true;
            if (isGrounded)
            {
                animator.SetBool("Walking", true);
            }
        }

        if (horizontalInput == 0) {
            animator.SetBool("Walking", false);
        }
        rigidbody2D.velocity = new Vector2(horizontalInput * speed, rigidbody2D.velocity.y);
    }

    void Jump() {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
        animator.SetBool("Jump", true);
        isGrounded = false;
        animator.SetBool("Walking", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jump", false);
            isGrounded = true;
        }
    }
}
