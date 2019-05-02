using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public GameObject mapGenerator;
    MapGenerator mg;
    void Start () {
        StartCoroutine(onStartUp());
        mapGenerator = GameObject.Find("Map Generator");
        mg = mapGenerator.GetComponent<MapGenerator>();
    }
    IEnumerator onStartUp () {
        yield return new WaitForSeconds(1);
        AstarPath.active.Scan();
    }
    public static GameMaster gm;
    
    public static void KillEnemy(Enemy enemy) {
        Destroy (enemy.gameObject);
    }
    public void NewGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
