using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour {

    GameObject roomManagerObj;
    RoomManager roomManager;

	void Start () {
        roomManagerObj = GameObject.Find("RoomManager");
        roomManager = GetComponent<RoomManager>();

        for (int i = 0; i < roomManager.rooms.Length; i++){
            if(roomManager.rooms[i].isDead){
                Debug.Log(roomManager.rooms[i].name);
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
