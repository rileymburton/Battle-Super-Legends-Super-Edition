using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour {
    
    public CombinedMove Cm;
    public BoxCollider2D hitbox = new BoxCollider2D();
    public bool move;
    GameObject  Player;
    Animator    animator;
    float       xoffset;
    int         offsetSwap;
    int         playerDamage;

    void Start()
    {
        animator        = this.GetComponent<Animator>();
        CombinedMove Cm = this.GetComponent<CombinedMove>();
        offsetSwap      = 1;
        hitbox.enabled  = false;
    }

    void Update()
    {
        if (Cm.facingRight == true)
        {
            offsetSwap = 1;
        } else if (Cm.facingRight == false)
        {
            offsetSwap = -1;
        }
        if (Cm.action == 1)//L
        {
            hitbox.size = new Vector2(.25f, .25f);//set size
            hitbox.offset = new Vector2(.2f * offsetSwap, 0);//set offset
            playerDamage = Cm.lightAttackDamage;
        } else if (Cm.action == 2)//H
        {
            hitbox.size = new Vector2(.25f, .25f);//set size
            hitbox.offset = new Vector2(.64f * offsetSwap, .64f);//set offset
            playerDamage = Cm.lightAttackDamage;
        }
    }
 
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision Detected");
        //EnemyBehaviors.enemyHealth -= playerDamage;
    }

    public void activate()
    {
        hitbox.enabled = true;
        move = true;
        Debug.Log("Hitbox Activated");
    }
    public void deactivate()
    {
        hitbox.enabled = false;
        move = false;
        Debug.Log("Hitbox Deactivated");
    }
    public void end()
    {
        Cm.action = 0;
        animator.SetInteger("action", 0);
        Debug.Log("Action set to 0");
    }
}
