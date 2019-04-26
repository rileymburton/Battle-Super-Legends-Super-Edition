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

    float rollSpeed = 5;
    int rollDuration = 40;

    float hitboxXSize = .25f;
    float hitboxYSize = .5f;
    float hitboxXOffset = .2f;
    float hitboxYOffset = 0;
    float startup = 5;
    float active = 5;
    float recovery = 15;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void attack()
    {
        if (controller.m_FacingRight)
        {
            hitboxXOffset = Mathf.Abs(hitboxXOffset);
        }
        else if (!controller.m_FacingRight)
        {
            hitboxXOffset = -Mathf.Abs(hitboxXOffset);
        }

        for (int i = 0; i < startup; i++)
        {
            hitbox.enabled = false;
        }
        for (int i = 0; i < active; i++)
        {
            hitbox.enabled = true;
        }
        for (int i = 0; i < recovery; i++)
        {
            hitbox.enabled = false;
        }
    }

    public void roll()
    {
        hitbox.enabled = false;
        
        if (controller.m_FacingRight)
        {
            rollSpeed = Mathf.Abs(rollSpeed);
        }
        else if (!controller.m_FacingRight)
        {
            rollSpeed = -Mathf.Abs(rollSpeed);
        }
        
        controller.m_Rigidbody2D.velocity = Vector2.zero;
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
