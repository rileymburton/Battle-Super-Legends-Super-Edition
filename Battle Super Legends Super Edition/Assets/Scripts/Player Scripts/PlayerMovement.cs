using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    public CombatManager combat;
    public Animator animator;
    public float horizontalMove = 0;
    public float runSpeed = 40;
    bool jump = false;
    bool crouch = false;
    Vector2 prevYPos;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("VSpeed", (transform.position.y - prevYPos.y) / Time.fixedDeltaTime);
		prevYPos = transform.position;
        animator.SetBool("Grounded", controller.m_Grounded);

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Attack"))
        {
            combat.attack();
        }
        if (Input.GetButtonDown("Roll"))
        {
            combat.roll();
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
