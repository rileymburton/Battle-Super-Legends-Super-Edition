using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporterScript : MonoBehaviour
{
    GameMaster GM;
    GameObject Player;
    bool isStartRoom = false;
    void Start()
    {
        GameObject gameMasterObj = GameObject.Find("GameMaster");
        GM = gameMasterObj.GetComponent<GameMaster>();
        Player = GameObject.FindGameObjectWithTag("Player");
        if(this.transform.position.x > -5 && this.transform.position.y > -5 && this.transform.position.x < 5 && this.transform.position.y < 5){
            Player.transform.position = this.transform.position;
            isStartRoom = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStartRoom && Vector3.Distance(Player.transform.position,this.transform.position) < 2f && Input.GetKeyDown(KeyCode.E)){
            GM.NewGame();
        }
    }
}
