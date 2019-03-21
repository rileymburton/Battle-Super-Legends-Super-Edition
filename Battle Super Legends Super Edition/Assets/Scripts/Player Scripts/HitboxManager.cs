using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour {
    
    public GameObject Player;
    public CombinedMove Cm;
    public BoxCollider2D hitbox = new BoxCollider2D();
    public bool move;
    Animator    animator;
    float       xoffset;
    int         offsetSwap;
    int         playerDamage;

    void Start()
    {
        animator       = Player.GetComponent<Animator>();
        Cm             = Player.GetComponent<CombinedMove>();
        offsetSwap     = 1;
        hitbox.enabled = false;
        move = false;
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
        } else if (Cm.action == 2)//H
        {
            hitbox.size = new Vector2(.25f, .5f);//set size
            hitbox.offset = new Vector2(.15f * offsetSwap, 0);//set offset
        }
        if (Cm.action == 0)
        {
            move = false;
        }
    }
 
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision Detected");
    }

    public void activate()
    {
        if (Cm.action != 3)
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
        hitbox.enabled = false;
        move = false;
        animator.SetInteger("action", 0);
        Debug.Log("Action set to 0");
    }
}
