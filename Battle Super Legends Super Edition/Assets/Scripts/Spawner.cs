﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject chest;

    void Start()
    {
        // rolls a number and generates either enemies or a chest or potentially nothing in a spawn point
        // 1 2 3 4 5 6 7 8 9 10 11 12 13 14 
        int roll = Random.Range(1,15);
        if (roll >= 1 && roll <= 3){
            Instantiate(enemy1, this.transform.position, Quaternion.identity);
        }
        else if (roll >= 4 && roll <=6){
            Instantiate(enemy2, this.transform.position, Quaternion.identity);
        }
        else if (roll >= 7 && roll <= 9){
            Instantiate(enemy3, this.transform.position, Quaternion.identity);
        }
        else if(roll == 10){
            Instantiate(chest, this.transform.position, Quaternion.identity);
        }
    }
}
