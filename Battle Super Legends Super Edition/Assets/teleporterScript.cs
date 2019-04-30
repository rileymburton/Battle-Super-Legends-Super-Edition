using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporterScript : MonoBehaviour
{
    bool isStartRoom = false;
    void Start()
    {
        GameObject gameMasterObj = GameObject.Find("GameMaster");
        GameMaster GM = gameMasterObj.GetComponent<GameMaster>();
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if(this.transform.position.x > -5 && this.transform.position.y > -5 && this.transform.position.x < 5 && this.transform.position.y < 5){
            Player.transform.position = this.transform.position;
            isStartRoom = true;
        }
        if(!isStartRoom && Vector3.Distance(Player.transform.position,this.transform.position) < 2f && Input.GetKeyDown("E")){
            GM.NewGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
