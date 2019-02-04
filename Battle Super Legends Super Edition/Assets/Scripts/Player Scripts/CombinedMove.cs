using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedMove : MonoBehaviour {

	public HitboxManager Hm;
	public KeybindingsScript Kb;
	private int   dashSpeedInputDuration = 40;

	//used by animator
	Animator       animator;
	SpriteRenderer spriteRenderer;
	public bool    facingRight;
	public int     action;
	int            moveDirection;
	int            direction;
	bool           grounded;
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
		jumpHeight    = setJumpHeight;
		airOptions    = setAirOptions;
		grounded      = true;
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
			action = 2;
			if (!grounded)
			{
				airOptions--;
			}
			transform.position = getJump();
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
			buttonHeld++;
			Debug.Log("Moving Left");
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
			animator.SetInteger("moveDirection", 2);
			action = 0;
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

		//stops Heavy attack from bounceing
		if((transform.position.y - prevYPos.y) < 0 && grounded)
		{
			animator.SetInteger("action", 0);
			Hm.move = false;
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
}