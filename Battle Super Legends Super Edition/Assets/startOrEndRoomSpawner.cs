using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startOrEndRoomSpawner : MonoBehaviour
{
    GameObject room;
    // Start is called before the first frame update
    void Start()
    {
        room = this.gameObject.transform.parent.gameObject;
        Debug.LogError(room.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
