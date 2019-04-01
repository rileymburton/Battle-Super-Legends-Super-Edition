using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    
    public static void KillEnemy(Enemy enemy) {
        Destroy (enemy.gameObject);
    }
}
