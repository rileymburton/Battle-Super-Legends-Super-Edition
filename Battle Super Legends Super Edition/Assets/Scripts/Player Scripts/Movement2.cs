using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
	private KeybindingsScript Kb;
    public  Rigidbody2D rb2D;
    public  bool flipSprite;
    public  int action;
    int   doubleJumps;
    int   setDoubleJumps;
    int   moveDirection;
    bool  grounded;
    float jumpHeight;
    float walkspeed;

    Animator       animator;
	SpriteRenderer spriteRenderer;
	Vector2        prevYPos;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
		spriteRenderer = this.GetComponent<SpriteRenderer>();

        setDoubleJumps = 1;
        doubleJumps    = setDoubleJumps;
        jumpHeight     = 5;
        flipSprite     = false;
        walkspeed      = .5f;
        grounded       = true;
    }

    // Update is called once per frame
    void Update()
    {
        //sets the action animation
        animator.SetInteger("action", action);
        //sets walking left or right
		animator.SetInteger("moveDirection", moveDirection);
        //sets grounded or not
		animator.SetBool("grounded", grounded);
        //flips the X axis of the sprite if needed
        spriteRenderer.flipX = flipSprite;
        //sets falling animation if airborn and not mid SRK
        if (action != 2 && !grounded)
			animator.SetFloat("vspeed", (transform.position.y - prevYPos.y) / Time.deltaTime);
		prevYPos = transform.position;

        //apply gravity
        Physics.gravity = new Vector2(0, -.1f);

        //moves left if left key is pressed
        if (Input.GetKeyDown(KeybindingsScript.Kb.left))
        {
            transform.Translate(walkspeed*-1, 0, 0);
            flipSprite = true;
            moveDirection = -1;
        }
        //moves right if right key is pressed
        if (Input.GetKeyDown(KeybindingsScript.Kb.right))
        {
            transform.Translate(walkspeed, 0, 0);
            flipSprite = false;
            moveDirection = 1;
        }
        //sets back to idle if no or both directions are pressed
        if (Input.GetKey(KeybindingsScript.Kb.right) && Input.GetKey(KeybindingsScript.Kb.left) && grounded ||
            !Input.GetKey(KeybindingsScript.Kb.right) && !Input.GetKey(KeybindingsScript.Kb.left) && grounded)
        {
            moveDirection = 0;
        }
        //makes the character jump
        if (Input.GetKey(KeybindingsScript.Kb.jump) && grounded == true)
        {
            grounded = false;
            rb2D.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
        //checks if a double jump is possible and jumps
        if (Input.GetKey(KeybindingsScript.Kb.jump) && grounded == false && doubleJumps > 0)
        {
            doubleJumps--;
            rb2D.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //sets grounded if it collides with the ground
        if (col.gameObject.tag == "obstacle")
        {
            grounded = true;
            doubleJumps = setDoubleJumps;
        }
    }
}
