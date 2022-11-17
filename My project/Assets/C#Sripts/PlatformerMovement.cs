using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1.0f;
    [SerializeField]
    float jumpSpeed = 1.0f;
    bool grounded = false;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteR;
    Rigidbody2D feet;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * moveSpeed;
        rb.velocity = velocity;
        
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            grounded = false;
            animator.SetTrigger("jump");
        }
        
        if(rb.velocity.y < -0.1f && !grounded)
        {
            animator.SetTrigger("fall");
        }
        
        animator.SetFloat("xInput", moveX);
        animator.SetBool("grounded", grounded);
        
        if(moveX < 0)
        {
            spriteR.flipX = true;
        }
        
        else if(moveX > 0)
        {
            spriteR.flipX = false;
        }

        float xInput = Input.GetAxis("Horizontal");
        GetComponent<Animator>().SetFloat("xInput", xInput);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
           grounded = true;
        }
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			grounded = false;
		}
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }
}
