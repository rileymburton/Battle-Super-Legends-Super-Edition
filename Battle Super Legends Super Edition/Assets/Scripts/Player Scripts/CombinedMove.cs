using System.Collections;
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
		jumpHeight    = setJumpHeight;
		airOptions    = setAirOptions;
		grounded      = false;
		facingRight   = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
				rb2D.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
			else if (airOptions > 0)
			{
				airOptions--;
				rb2D.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
			}
		}

		//resets when keys are released
		if (Input.GetKeyUp(KeybindingsScript.Kb.left) ||
			Input.GetKeyUp(KeybindingsScript.Kb.right))
		{
			buttonHeld = 0;
			moveDirection = 0;
		}

		if(grounded && !wasGrounded)
			action = 0;

		wasGrounded = grounded;
		Debug.Log("Grounded: "+grounded);
	}

	//sets grounded if colliding with ground
	void OnCollisionEnter2D(Collision2D col)
    {
		Debug.Log("Collision Detected: "+col.ToString());
		if (col.gameObject.tag == "Obstacle")
		{
			Debug.Log("Touching Ground");
			grounded = true;
		}
	}
	void OnCollisionStay2D(Collision2D col)
    {
		if (col.gameObject.tag == "Obstacle")
		{
			Debug.Log("Touching Ground");
			grounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D col)
    {
		if (col.gameObject.tag == "Obstacle")
		{
			Debug.Log("Leaving");
			grounded = false;
			airOptions = setAirOptions;
		}
	}
	
	public void getRoll(bool facingRight, bool grounded)
	{
		if (grounded)
		{
			action = 3;
			animator.SetInteger("action", action);
			rb2D.velocity = Vector2.zero;
			for(int i = 0; i < 20; i++)
			{
				hurtbox1.enabled = false;
				hurtbox2.enabled = false;
				if (facingRight)
				{
					rb2D.AddForce(new Vector2(.2f, 0), ForceMode2D.Impulse);
				}
				if (!facingRight)
				{
					rb2D.AddForce(new Vector2(-.2f, 0), ForceMode2D.Impulse);
				}
			}
			if (!Hm.move)
			{
				hurtbox1.enabled = true;
				hurtbox2.enabled = true;
				rb2D.velocity = Vector2.zero;
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