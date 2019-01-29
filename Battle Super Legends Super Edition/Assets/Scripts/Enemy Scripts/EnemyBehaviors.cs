using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviors : MonoBehaviour {

	BoxCollider2D hurtbox = new BoxCollider2D();
	public GameObject Player;
	HitboxManager Hm = new HitboxManager();
	CombinedMove Cm = new CombinedMove();
	int enemyHealth = 100;
	int enemyDamage = 20;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        
    }
}
