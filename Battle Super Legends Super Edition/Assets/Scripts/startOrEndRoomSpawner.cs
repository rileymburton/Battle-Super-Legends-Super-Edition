using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startOrEndRoomSpawner : MonoBehaviour
{
    GameObject room;
    public GameObject teleporter;
    public GameObject shop;


    MapGenerator mg = new MapGenerator();
    // Start is called before the first frame update
    void Start()
    {
        System.Threading.Thread.Sleep(3000);
        int finalX = mg.returnXMax(mg.xMax);
        int finalY = mg.returnYMax(mg.yMax);

        Debug.LogError(finalX + " " + finalY);
        room = this.gameObject.transform.parent.gameObject;
        if (room.transform.position.x == 0 && room.transform.position.y == 0){
            Instantiate(teleporter,this.transform.position,Quaternion.identity);
        }
        else if(room.transform.position.x == finalX && room.transform.position.y == finalY){
            Instantiate(teleporter,this.transform.position,Quaternion.identity);
        }
        
    }
}
