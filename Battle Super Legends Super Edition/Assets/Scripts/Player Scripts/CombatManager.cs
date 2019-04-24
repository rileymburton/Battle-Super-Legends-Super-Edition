using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public BoxCollider2D hitbox;
    public BoxCollider2D headHitbox;
    public PlayerController controller;
    public PlayerMovement movement;
    public Animator animator;
    float rollSpeed = 30;
    int rollDuration = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void attack()
    {
        
    }

    public void roll()
    {
        if (controller.m_FacingRight)
        {
            rollSpeed = Mathf.Abs(rollSpeed);
        }
        else if (!controller.m_FacingRight)
        {
            rollSpeed = -Mathf.Abs(rollSpeed);
        }
        
        for (int i = 0; i < rollDuration; i++)
        {
            headHitbox.enabled = false;
            Vector2 rollForce = new Vector2(rollSpeed, 0);
            controller.m_Rigidbody2D.AddForce(rollForce, ForceMode2D.Impulse);
            animator.SetBool("Roll", true);
        }
        headHitbox.enabled = true;
        controller.Move(0, false, false);
        animator.SetBool("Roll", false);
    }
}
