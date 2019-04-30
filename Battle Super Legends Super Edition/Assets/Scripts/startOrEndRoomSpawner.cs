using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startOrEndRoomSpawner : MonoBehaviour
{
    GameObject room;
    public GameObject teleporter;

    private GameObject mapGenObj;
    public GameObject shop;
    int finalY;
    int finalX;


    // Start is called before the first frame update
    void Start()
    {
        mapGenObj = GameObject.Find("Map Generator");
        MapGenerator Mg = mapGenObj.GetComponent<MapGenerator>();
        finalX = Mg.xMax;
        finalY = Mg.yMax;
        
        room = this.gameObject.transform.parent.gameObject;
        if (room.transform.position.x == 0 && room.transform.position.y == 0){
            Instantiate(teleporter,this.transform.position,Quaternion.identity);
        }
        else if(room.transform.position.x == finalX && room.transform.position.y == finalY){
            Instantiate(teleporter,this.transform.position,Quaternion.identity);
        }
        
    }
}
