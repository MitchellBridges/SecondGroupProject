using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMoveSript : MonoBehaviour

{
	public float walkSpeed;
	private float moveInput;
	public bool isGrounded;
	private Rigidbody2D rb;
	public LayerMask groundMask;

	public PhysicsMaterial2D bounceMat, normalMat;
	public bool canJump = true;
	public float jumpValue = 0.0f;
	//Code from PlatformerMovement
	Animator animator;
	SpriteRenderer spriteR;
	Rigidbody2D feet;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		//Code from PlatformerMovement
		animator = GetComponent<Animator>();
		spriteR = GetComponent<SpriteRenderer>();
	}


	void Update()
	{
		float moveX = Input.GetAxis("Horizontal");
		moveInput = Input.GetAxisRaw("Horizontal");

		if (jumpValue == 0.0f && isGrounded)
		{
			rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
		}

		isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.9f),
		new Vector2(0.9f, 0.4f), 0f, groundMask);


		if (jumpValue > 0)
		{
			rb.sharedMaterial = bounceMat;
		}

		else
		{
			rb.sharedMaterial = normalMat;
		}


		if (Input.GetKey("space") && isGrounded && canJump)
		{
			jumpValue += 0.1f;
		}

		if (Input.GetKeyDown("space") && isGrounded && canJump)
		{
			rb.velocity = new Vector2(0.0f, rb.velocity.y);
			animator.SetTrigger("jump");
		}
		animator.SetFloat("xInput", moveX);
		animator.SetBool("grounded", isGrounded);

		if (jumpValue >= 20f && isGrounded)
		{
			float tempx = moveInput * walkSpeed;
			float tempy = jumpValue;
			rb.velocity = new Vector2(tempx, tempy);
			Invoke("ResetJump", 0.2f);
		}

		if (Input.GetKeyUp("space"))
		{
			if (isGrounded)
			{
				rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
				jumpValue = 0.0f;
			}
			canJump = true;
		}

		if (moveX < 0)
		{
			spriteR.flipX = true;
		}

		else if (moveX > 0)
		{
			spriteR.flipX = false;
		}

		float xInput = Input.GetAxis("Horizontal");
		GetComponent<Animator>().SetFloat("xInput", xInput);
	}

	private void ResetJump()
	{
		canJump = false;
		jumpValue = 0;

	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.9f), new Vector2(0.9f, 0.1f));
	}


}
