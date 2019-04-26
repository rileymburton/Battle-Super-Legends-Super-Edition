using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChadEnemyScript : MonoBehaviour 
{
    private GameObject player;
    public float distanceToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, this.transform.position);
        if(distanceToPlayer < 8f){
            GetComponent<AIPath>().destination = player.transform.position;
        }
        if(distanceToPlayer > 8f){
            GetComponent<AIPath>().destination = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        }
    }
}
