using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GameMaster : MonoBehaviour
{
    void Start () {
        StartCoroutine(onStartUp());
    }
    IEnumerator onStartUp () {
        yield return new WaitForSeconds(1);
        AstarPath.active.Scan();
    }
    public static GameMaster gm;
    
    public static void KillEnemy(Enemy enemy) {
        Destroy (enemy.gameObject);
    }
}
