using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedMove : MonoBehaviour {

	public HitboxManager Hm;
	public KeybindingsScript Kb;
	public HealthDisplay Hd;
	private int   dashSpeedInputDuration = 40;
	public BoxCollider2D hurtbox1;
	public CircleCollider2D hurtbox2;

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
	int   setAirOptions;
	int   buttonHeld;
	int   airOptions;
	float jumpHeight;
	float gravity;
	float dashSpeed;
	float walkspeed;
	float setJumpHeight;
	float speedMultiplier;
	float lastTapTime;
	float tapSpeed;

	//used for combat
	public int playerHealth;
	public int maxHealth = 100;
	public int lightAttackDamage = 50;
	public int heavyAttackDamage = 110;

	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator>();
		spriteRenderer = this.GetComponent<SpriteRenderer>();

		playerHealth  = maxHealth; //changeable
		setJumpHeight = .18f;      //changeable
		setAirOptions = 1;         //changeable
		walkspeed     = .06f;      //changeable
		dashSpeed     = 1.75f;     //changeable
		gravity       = .013f;     //changeable
		tapSpeed      = .5f;       //changeable
		jumpHeight    = setJumpHeight;
		airOptions    = setAirOptions;
		grounded      = true;
		facingRight   = true;
		lastTapTime   = Time.time;
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
				action = 2;
				if (!grounded)
				{
					airOptions--;
				}
				transform.position = getJump();
		}
		//roll
		if (Input.GetKeyDown(KeybindingsScript.Kb.heavyAttack))//activate S
		{
			action = 3;
			getRoll(facingRight, grounded);
		}

		//move left
		if (Input.GetKey(KeybindingsScript.Kb.left) &&
			!Input.GetKey(KeybindingsScript.Kb.right))
		{
			moveDirection = -1;
			if (buttonHeld >= dashSpeedInputDuration)
			{
				speedMultiplier = dashSpeed*-1;
			} else if (buttonHeld < dashSpeedInputDuration) {
				speedMultiplier = -1;
			}
			if (grounded)
			{
				action = 0;
				facingRight = false;
				transform.Translate(walkspeed*speedMultiplier, 0, 0);
			}
			else if (!grounded)
			{
				transform.Translate(walkspeed*.85f*speedMultiplier, 0, 0);
			}
			Debug.Log("Moving Left");
			buttonHeld++;
		}

		//move right
		if (Input.GetKey(KeybindingsScript.Kb.right) &&
			!Input.GetKey(KeybindingsScript.Kb.left))
		{
			moveDirection = 1;
			if (buttonHeld >= dashSpeedInputDuration)
			{
				speedMultiplier = dashSpeed;
			} else if (buttonHeld < dashSpeedInputDuration) {
				speedMultiplier = 1;
			}
			if (grounded)
			{
				action = 0;
				facingRight = true;
				transform.Translate(walkspeed*speedMultiplier, 0, 0);
			}
			else if (!grounded)
			{
				transform.Translate(walkspeed*.85f*speedMultiplier, 0, 0);
			}
			buttonHeld++;
			Debug.Log("Moving Right");
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
		if (!grounded && transform.position.y > -.8f)
		{
			transform.position = getGravity(grounded);
		} else if (transform.position.y <= -.8f) {
			grounded = true;
			transform.position = new Vector2(transform.position.x, -.8f);
			jumpHeight = setJumpHeight;
			airOptions = setAirOptions;	
		}



		if(grounded && !wasGrounded)
			action = 0;

		wasGrounded = grounded;
	}

	//jump method, calls gravity
	public Vector2 getJump()
	{	
		jumpHeight = setJumpHeight;
		grounded = false;
		transform.position = getGravity(grounded);

		Debug.Log("Jumping");
		return transform.position;
	}

	//calculate gravity
	private Vector2 getGravity(bool grounded)
	{
		if (!grounded)
		{
			transform.Translate(0, jumpHeight, 0);
			jumpHeight -= gravity;
		}
		return transform.position;
	}
	
	public void getRoll(bool facingRight, bool grounded)
	{
		if (grounded)
		{
			action = 3;
			for(int i = 30; i > 0; i--)
			{
				hurtbox1.enabled = false;
				hurtbox2.enabled = false;
				if (facingRight)
				{
					transform.Translate(0.1f, 0, 0);
				}
				if (!facingRight)
				{
					transform.Translate(-0.1f, 0, 0);
				}
			}
			hurtbox1.enabled = true;
			hurtbox2.enabled = true;
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