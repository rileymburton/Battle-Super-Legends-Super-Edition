﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedMove : MonoBehaviour {

	public HitboxManager Hm;
	public KeybindingsScript Kb;
	private HealthDisplay Hd;
	public BoxCollider2D hurtbox1;
	public CircleCollider2D hurtbox2;
	public Rigidbody2D rb2D;

	//used by animator
	Animator       animator;
	SpriteRenderer spriteRenderer;
	public bool    facingRight;
	public int     action;
	int            moveDirection;
	int            direction;
	bool           grounded;
	bool 		   wasGrounded;
	Vector2        prevYPos;

	//used by movement
	int   dashSpeedInputDuration = 40;
	int   setAirOptions;
	int   buttonHeld;
	int   airOptions;
	float jumpHeight;
	float gravity;
	float dashSpeed;
	float walkspeed;
	float setJumpHeight;
	float speedMultiplier;

	//used for combat
	public int playerHealth;
	public int maxHealth = 100;

	// Use this for initialization
	void Start () 
	{
		rb2D = this.GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator>();
		spriteRenderer = this.GetComponent<SpriteRenderer>();

		playerHealth  = maxHealth; //changeable
		setJumpHeight = 0.18f;     //changeable
		setAirOptions = 1;         //changeable
		walkspeed     = 0.06f;     //changeable
		dashSpeed     = 1.75f;     //changeable
		gravity       = 0.0f;    //changeable
		jumpHeight    = setJumpHeight;
		airOptions    = setAirOptions;
		grounded      = false;
		facingRight   = true;
	}
	
	// Update is called once per frame
	void Update () {
		//update animator
		animator.SetInteger("action", action);
		animator.SetInteger("moveDirection", moveDirection);
		animator.SetBool("grounded", grounded);
		animator.SetBool("facingRight", facingRight);
		if (facingRight){spriteRenderer.flipX = false;}
		if (!facingRight){spriteRenderer.flipX = true;}
		//collect vertical speed
		if (action != 2)
			animator.SetFloat("vspeed", 
				(transform.position.y - prevYPos.y) / Time.deltaTime);
		prevYPos = transform.position;

		//light attack
		if (Input.GetKeyDown(KeybindingsScript.Kb.lightAttack))
		{
			action = 1;
			if (!grounded)
			{
				airOptions--;
			}
			transform.Translate((.15f*moveDirection), 0, 0);
		}
		//heavy attack
		if (Input.GetKeyDown(KeybindingsScript.Kb.mediumAttack))//activate H
		{
			//getInventoryItem();
			if (grounded)
			{
				action = 2;
				transform.position = getJump();
			}
		}
		//roll
		if (Input.GetKeyDown(KeybindingsScript.Kb.heavyAttack))//activate S
		{
			action = 3;
			getRoll(facingRight, grounded);
			Debug.Log("Should be Rolling");
		}

		//move left
		if (Input.GetKey(KeybindingsScript.Kb.left))
		{
			moveDirection = -1;
			if (buttonHeld >= dashSpeedInputDuration)
			{
				speedMultiplier = dashSpeed*-1;
			} else if (buttonHeld < dashSpeedInputDuration) {
				speedMultiplier = -1;
			}
			action = 0;
			facingRight = false;
			transform.Translate(walkspeed*speedMultiplier, 0, 0);
			buttonHeld++;
		}

		//move right
		if (Input.GetKey(KeybindingsScript.Kb.right))
		{
			moveDirection = 1;
			if (buttonHeld >= dashSpeedInputDuration)
			{
				speedMultiplier = dashSpeed;
			} else if (buttonHeld < dashSpeedInputDuration) {
				speedMultiplier = 1;
			}
			action = 0;
			facingRight = true;
			transform.Translate(walkspeed*speedMultiplier, 0, 0);
			buttonHeld++;
		}
		
		//jump
		if (Input.GetKeyDown(KeybindingsScript.Kb.jump))
		{
			if (grounded)
				transform.position = getJump();
			else if (airOptions > 0)
			{
				airOptions--;
				transform.position = getJump();
			}
		}

		//resets when keys are released
		if (Input.GetKeyUp(KeybindingsScript.Kb.left) ||
			Input.GetKeyUp(KeybindingsScript.Kb.right))
		{
			buttonHeld = 0;
			moveDirection = 0;
		}

		//activate gravity if airborn
		if (!grounded)
		//{
			//transform.position = getGravity(grounded);
		/*}  else if (hurtbox2) {
			grounded = true;
			transform.position = new Vector2(transform.position.x, -.8f);
			jumpHeight = setJumpHeight;
			airOptions = setAirOptions;	
		}
		*/

		if(grounded && !wasGrounded)
			action = 0;

		wasGrounded = grounded;
	}

	//sets grounded if colliding with ground
	

	//void OnCollisionStay2D(Collision2D col)
	void OnCollisionStay2D(Collision2D col)
    {
		Debug.Log("rkrkrkrk");
		if (col.gameObject.tag == "obstacle")
		{
			Debug.Log("Touching Ground");
			grounded = true;
			jumpHeight = setJumpHeight;
			airOptions = setAirOptions;	
		}
	}

	//jump method, calls gravity
	public Vector2 getJump()
	{	
		//jumpHeight = setJumpHeight;
		grounded = false;
		//transform.position = getGravity(grounded);
		rb2D.AddForce(new Vector3(0, jumpHeight, 0), ForceMode2D.Impulse);

		Debug.Log("Jumping");
		return transform.position;
	}

	/*
	//calculate gravity
	private Vector2 getGravity(bool grounded)
	{
		if (!grounded)
		{
			transform.Translate(0, jumpHeight, 0);
			jumpHeight -= gravity;
		}
		return transform.position;
	}*/
	
	public void getRoll(bool facingRight, bool grounded)
	{
		if (grounded)
		{
			action = 3;
			animator.SetInteger("action", action);
			for(int i = 0; i < 20; i++)
			{
				hurtbox1.enabled = false;
				hurtbox2.enabled = false;
				if (facingRight)
				{
					transform.Translate(0.01f, 0, 0);
				}
				if (!facingRight)
				{
					transform.Translate(-0.01f, 0, 0);
				}
			}
			if (!Hm.move)
			{
				hurtbox1.enabled = true;
				hurtbox2.enabled = true;
			}
		}
	}

	/* 
	public int getInventoryItem()
	{
		for (int i = 0; i < 4; i++)
		{
			switch (Hd.inventory[i]){
                case 0:
                    return 0;
                break;

                case 1:
                    
                break;

                case 2:
                    
                break;

                case 3:
                    
                break;

                case 4:
                    
                break;

                case 5:
                    
                break;

                case 6:
                    
                break;

                case 7:
                    
                break;

                case 8:
                    
                break;

                case 9:
                    
                break;
		}
		return -1;
	}
	*/
}